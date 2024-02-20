using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace cadastro_de_empresas
{
    public partial class Cadastro : Form
    {
        //Endereco endereco;
        Empresa empresa;
        private HttpClient _client = new HttpClient();

        public List<Empresa> listEmpresa = new List<Empresa>();
        public Cadastro()
        {
            InitializeComponent();
            try
            {
                txEndereco_Cep.TextChanged += async (s, e) =>
                {
                    string cepSemTraco = txEndereco_Cep.Text.Replace(".", "");
                    cepSemTraco.Replace("-", "");

                    if (cepSemTraco.Length == 8)
                    {

                        var response = await _client.GetStringAsync($"https://viacep.com.br/ws/{cepSemTraco}/json/");
                        //MessageBox.Show(response);
                        var endereco = JsonConvert.DeserializeObject<Endereco>(response);

                        txEndereco_Logradouro.Text = endereco.Logradouro;
                        txEndereco_Bairro.Text = endereco.Bairro;
                        cbEndereco_Estado.Text = endereco.Uf;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO");                
            }
            
        }
        private void btContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampus())
                {


                    empresa = new Empresa()
                    {
                        Cnpj = maskCnpj.Text,
                        RazaoSocial = txRazao.Text,
                        NomeFantasia = txNomeFantasia.Text,
                        SituacaoCadastral = cbSituacaoCadastral.Text,
                        RegimeTributario = GetRadioButton(gbRegime).ToString(),
                        DataInicioAtividade = dataInicio.Value,
                        Telefone = maskTelefone.Text,
                        CapitalSocial = Convert.ToDouble(txCapitalSocial.Text),
                        EnderecoEmpresa = new Endereco
                        {
                            Uf = cbEndereco_Estado.Text,
                            Cep = txEndereco_Cep.Text,
                            Bairro = txEndereco_Bairro.Text,
                            Logradouro = txEndereco_Logradouro.Text
                        },
                        Tipo = GetRadioButton(gbTipo).ToString(),
                        PorteEmpresa = GetRadioButton(gbPorte).ToString(),
                        NaturezaJuridica = cbNaturezaJuridica.Text,
                        NomeProprietario = txNomeProprietario.Text,
                    };

                    bool resultadoCpf = Validacoes.ValidacaoCpf(maskCpf.Text);
                    if (resultadoCpf)
                    {
                        empresa.Cpf = maskCpf.Text;
                        listEmpresa.Add(empresa);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = listEmpresa;
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido", "ERRO");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "erro");
            }

        }
        private string GetRadioButton(GroupBox grb)
        {
            return grb.Controls.OfType<RadioButton>().SingleOrDefault(radio => radio.Checked == true).Text;
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            try
            {

                maskCnpj.Text = string.Empty;
                txRazao.Text = string.Empty;
                txNomeFantasia.Text = string.Empty;
                cbSituacaoCadastral.Text = string.Empty;
                rbRegime_Lucro.Checked = false;
                rbRegime_Real.Checked = false;
                rbRegime_Simples.Checked = false;
                dataInicio.Text = string.Empty;
                maskTelefone.Text = string.Empty;
                txCapitalSocial.Text = string.Empty;
                rbTipo_Filial.Checked = false;
                rbTipo_Matriz.Checked = false;
                rbPorte_Grande.Checked = false;
                rbPorte_Medio.Checked = false;
                rbPorte_Pequeno.Checked = false;
                cbNaturezaJuridica.Text = string.Empty;
                txNomeProprietario.Text = string.Empty;
                maskCpf.Text = string.Empty;
            }
            catch (Exception ex)
            {

                maskCnpj.Text = string.Empty;
                txRazao.Text = string.Empty;
                txNomeFantasia.Text = string.Empty;
                cbSituacaoCadastral.Text = string.Empty;
                rbRegime_Lucro.Checked = false;
                rbRegime_Real.Checked = false;
                rbRegime_Simples.Checked = false;
                dataInicio.Text = string.Empty;
                maskTelefone.Text = string.Empty;
                txCapitalSocial.Text = string.Empty;
                rbTipo_Filial.Checked = false;
                rbTipo_Matriz.Checked = false;
                rbPorte_Grande.Checked = false;
                rbPorte_Medio.Checked = false;
                rbPorte_Pequeno.Checked = false;    
                cbNaturezaJuridica.Text = string.Empty;
                txNomeProprietario.Text = string.Empty;
                maskCpf.Text = string.Empty;
                MessageBox.Show(ex.Message, "ERRO");

            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                listEmpresa.RemoveAt(index);
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = listEmpresa;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Formato inválido! {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado! {ex.Message}");
            }
        }
        private bool estado;
        private bool ValidaCampus()
        {
            bool estado = false;
            if (maskCnpj.Text == "") //ou String.Empty = string vazia
            {
                //estado = false;
                errorProvider1.SetError(maskCnpj, "Campo obrigatório!");
            }
            else if (txRazao.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(txRazao, "Campo obrigatório!");
            }
            else if (txNomeFantasia.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(txNomeFantasia, "Campo obrigatório!");
            }
            else if (cbSituacaoCadastral.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(cbSituacaoCadastral, "Campo obrigatório!");
            }
            else if (maskTelefone.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(maskTelefone, "Campo obrigatório!");
            }
            else if (txCapitalSocial.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(txCapitalSocial, "Campo obrigatório!");
            }
            else if (txEndereco_Cep.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(txEndereco_Cep, "Campo obrigatório!");
            }
            else if (cbNaturezaJuridica.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(cbNaturezaJuridica, "Campo obrigatório!");
            }
            else if (txNomeProprietario.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(txNomeProprietario, "Campo obrigatório!");
            }
            else if (maskCpf.Text == "")
            {
                //estado = false;
                errorProvider1.SetError(maskCpf, "Campo obrigatório!");
            }
            else
            {
                estado = true;
            }
            return estado;

        }
    }
}
