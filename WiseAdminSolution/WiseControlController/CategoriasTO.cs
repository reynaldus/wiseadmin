using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
	public class CategoriasTO:ControllerMaster.ControllerMaster
	{
		#region "Atributos"
		private int _codigocat;
		private string _descrcat;
		private CategoriasDAO _dao;
		#endregion

		#region "GETTERS E SETTERS"
		public int CodigoCat
		{
			get	{	return this._codigocat;	}
			set	{	this._codigocat = value;	}
		}
		public string DescrCat
		{
			get	{	return this._descrcat;	}
			set	{	this._descrcat = value;	}
		}
		
		#endregion

		#region "Métodos"
		public List<Object> GerenciaCategoriasTO(int acao, String ConnectionString)
		{
			try
			{
				lista_dados = new List<object>();
				dt = new System.Data.DataTable();
				dt = _dao.GerenciaCategorias(this._codigocat, this._descrcat, acao, ConnectionString);
				
                if (! (dt == null))
				 {
					if (dt.Rows.Count > 0)
					{
						if (acao !=2)
						{
							lista_dados.Add(dt.Rows[0][0].ToString());
						}
						else
						{
							for (int X = 0; X < dt.Rows.Count; X++)
							{
								CategoriasTO item = new CategoriasTO(false);
								item.CodigoCat = int.Parse(dt.Rows[X]["CODIGO"].ToString());
								item.DescrCat = dt.Rows[X]["DESCRCAT"].ToString();
								lista_dados.Add(item);
								}
							}
						}
					}
					return lista_dados;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			#endregion

			#region "Construtores"
			public CategoriasTO(bool conbd)
			{
                try
                {
                    if(conbd)
				{
					this._dao = new CategoriasDAO();
				}
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
				
			}
			#endregion
		}
	}
	
		