/*
 * Resumo do que esta biblioteca faz:
 * pega respostas em formato json geradas de apis
 * e as converte pra onjetos, listas de objetos ou até mesmo dicionarios de objetos
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using APIJsonResultObjectLib.CustomException;

namespace APIJsonResultObjectLib
{
    [Description("Use this class to convert a json file to a only one object")]
    public class JsonToObject
    {
        [DisplayName("Caminho do arquivo json")]
        [Description("Caminho onde está localizado o arquivo json")]
        public string SourcePath { get; private set; }
        
        [DisplayName("Objeto a ser tornado")]
        [Description("Objeto o qual o aquivo json será convertido")]
        public object Obj { get; private set; }

        public JsonToObject(string sourcePath, object obj)
        {
            SourcePath = sourcePath;
            Obj = obj;
        }

        public JsonToObject(string sourcePath)
        {
            SourcePath = sourcePath;
        }

        [Description("if your object has a full construction use this")]
        public async Task<object> ConvertToObjectDefinedAsync()
        {
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            string rows;
            using (StringReader sr = new StringReader(SourcePath))
            {
                rows = await sr.ReadToEndAsync();
            }

            object result = serializador.Deserialize(rows, Obj.GetType());
            
            return result??throw new ExcecaoPersonalizada("Isn't possible generate your object");
        }
        
        [Description("If your object hasn't a full construction use this, use object to receive the result")]
        public async Task<object> ConvertToObjectUndefinedAsync()
        {
            JavaScriptSerializer serializador = new JavaScriptSerializer();

            string rows;
            using (StringReader sr = new StringReader(SourcePath))
            {
                rows = await sr.ReadToEndAsync();
            }

            object result = serializador.DeserializeObject(rows);

            return result ?? throw new ExcecaoPersonalizada("Isn't possible generate your object");
        }
    }
}