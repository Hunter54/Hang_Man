using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Spanzuratoare
{
	public class DefDex
	{
		static public string GetDef(string cuvant)
		{
			string url = @"https://dexonline.ro/definitie/" + Uri.EscapeUriString(cuvant) + "/json?";
			var request = WebRequest.Create(url);
			request.ContentType = "application/json; charset=utf-8";
			string definitie = "";
            
            try
			{
				var response = (HttpWebResponse)request.GetResponse();
				string text;
				using (var sr = new StreamReader(response.GetResponseStream()))
				{
					text = sr.ReadToEnd();
				}
				dynamic parsed = JsonConvert.DeserializeObject(text);
				try
				{
					definitie = parsed.definitions[0].internalRep.ToString();
				}
				catch
				{
					definitie = parsed.definitions[1].internalRep.ToString();
				}
                if(definitie.Length<30)
                   definitie = parsed.definitions[1].internalRep.ToString();
                var CharsToRemove = new string[] { "@", "$", "#", "*","&",";","^","%"};
				foreach(var c in CharsToRemove)
				{
					definitie = definitie.Replace(c, string.Empty);
				}

                definitie = Regex.Replace(definitie,@"\[.*?\]",string.Empty);
				definitie = Regex.Replace(definitie, @"\{.*?\}", string.Empty);
                definitie = Regex.Replace(definitie, @"[0-9]{2,3}", string.Empty);
				
			}
			catch
			{
				return "Nu exista conexiune la internet sau definitia cuvantului nu a putut fi redata";
			}
			return definitie;
		}
	}
}
