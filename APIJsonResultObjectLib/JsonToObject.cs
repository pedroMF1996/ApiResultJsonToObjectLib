/*
 * Resumo do que esta biblioteca faz:
 * pega respostas em formato json geradas de apis
 * e as converte pra onjetos, listas de objetos ou até mesmo dicionarios de objetos
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace APIJsonResultObjectLib
{
    [Description("Use this class to convert a json file to a object")]
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
        public async Task<object> ConvertToObjectDefined()
        {
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            using (StringReader sr = new StringReader(SourcePath))
            {
                string rows = await sr.ReadToEndAsync();
            }

            Type t = Obj.GetType();
            return serializador.Deserialize(SourcePath, Obj.GetType());

        }
    }
}