using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCounterLibrary;

public class Service : IService
{
	public Dictionary<string, int> GetDictionary(string text)
    {
		return Dictionary.GetDictionaryWMThreading(text);
    }
}
