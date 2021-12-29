﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;


namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    
    
    /// <summary>
    /// Interface para a tabela K_TRN_MARCAS_VITOR
    /// </summary>
    public partial interface IMarcasVitor : IEntityBase
    {
        
        /// <summary>
        /// Nome (NOME.)
        /// Opcional = N, Invisível = False, Tamanho = 400
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("BEF Code Generator", "20.1.0.20")]
        string Nome
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// Interface para o DAO para a tabela K_TRN_MARCAS_VITOR
    /// </summary>
    public partial interface IMarcasVitorDao : IBusinessEntityDao<IMarcasVitor>
    {
    }
    
    /// <summary>
    /// DAO para a tabela K_TRN_MARCAS_VITOR
    /// </summary>
    public partial class MarcasVitorDao : BusinessEntityDao<MarcasVitor, IMarcasVitor>, IMarcasVitorDao
    {
        
        public static MarcasVitorDao CreateInstance()
        {
            return CreateInstance<MarcasVitorDao>();
        }
    }
    
    /// <summary>
    /// MarcasVitor
    /// </summary>
    [EntityDefinitionName("K_TRN_MARCAS_VITOR")]
    [DataContract(Namespace = "http://Benner.Tecnologia.Common.DataContracts/2007/09", Name = "EntityBase")]
    public partial class MarcasVitor : BusinessEntity<MarcasVitor>, IMarcasVitor
    {
        
        /// <summary>
        /// Possui constantes para retornarem o nome dos campos definidos no Builder para cada propriedade
        /// </summary>
		public static class FieldNames
		{
			public const string Nome = "NOME";
		}

        
        /// <summary>
        /// Nome (NOME.)
        /// Opcional = N, Invisível = False, Tamanho = 400
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("BEF Code Generator", "20.1.0.20")]
        public string Nome
        {
            get
            {
                return Fields["NOME"] as System.String;
            }
            set
            {
                Fields["NOME"] = value;
            }
        }
    }
}
