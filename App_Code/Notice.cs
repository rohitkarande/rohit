using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for Notice
/// </summary>
public class Notice
{
    	 public Notice()
        {
        }

        public int[] SrNo_GUID { get; set; }
        public string _Title { get; set; }
        public string _Message { get; set; }
        public string _FlatNo { get; set; }
        public string _Building { get; set; }
        public string _Sector { get; set; }
        public string _Township { get; set; }
        public string _Error { get; set; }
	
}
