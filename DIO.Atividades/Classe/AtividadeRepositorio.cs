using System;
using System.Collections.Generic;
using DIO.Atividades.Interfaces;

namespace DIO.Atividades
{
	public class AtividadeRepositorio : IRepositorio<Atividade>
	{
        private List<Atividade> listaAtividade = new List<Atividade>();
		public void Atualiza(int id, Atividade objeto)
		{
			listaAtividade[id] = objeto;
		}

		public void Conclui(int id)
		{
			listaAtividade[id].Concluir();
		}

		public void Insere(Atividade objeto)
		{
			listaAtividade.Add(objeto);
		}

		public List<Atividade> Lista()
		{
			return listaAtividade;
		}

		public int ProximoId()
		{
			return listaAtividade.Count;
		}

		public Atividade RetornaPorId(int id)
		{
			return listaAtividade[id];
		}
	}
}