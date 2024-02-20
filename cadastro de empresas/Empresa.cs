using System;

namespace cadastro_de_empresas
{
    public class Empresa
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string SituacaoCadastral { get; set; }
        public string RegimeTributario { get; set; }
        public DateTime DataInicioAtividade { get; set; }
        public string Telefone { get; set; }
        public double CapitalSocial { get; set; }
        public Endereco EnderecoEmpresa { get; set; }
        public string Tipo { get; set; }
        public string PorteEmpresa { get; set; }
        public string NaturezaJuridica { get; set; }
        public string NomeProprietario { get; set; }
        public string Cpf { get; set; }

        public Empresa()
        {
        }
        public Empresa(string cnpj, string razaoSocial, string nomeFantasia, string situacaoCadastral, string regimeTributario, DateTime dataInicioAtividade, string telefone, double capitalSocial, Endereco endereco, string tipo, string porteEmpresa, string naturezaJuridica, string nomeProprietario, string cpf)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            SituacaoCadastral = situacaoCadastral;
            RegimeTributario = regimeTributario;
            DataInicioAtividade = dataInicioAtividade;
            Telefone = telefone;
            CapitalSocial = capitalSocial;
            EnderecoEmpresa = endereco;
            Tipo = tipo;
            PorteEmpresa = porteEmpresa;
            NaturezaJuridica = naturezaJuridica;
            NomeProprietario = nomeProprietario;
            Cpf = cpf;
        }
    }
}
