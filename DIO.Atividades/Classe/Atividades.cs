using System;

namespace DIO.Atividades

{
    public class Atividade : EntidadeBase
    {
        // Atributos
		private  Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private string Data { get; set; }
        private bool Concluido {get; set;}

        // Métodos
		public Atividade(int id, Genero genero, string titulo, string descricao, string data)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Data = data;
            this.Concluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Tipo da Atividade: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Data de Conclusão: " + this.Data + Environment.NewLine;
            retorno += "Concluído: " + this.Concluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaConcluido()
		{
			return this.Concluido;
		}
        public void Concluir() {
            this.Concluido = true;
        }
    }
}