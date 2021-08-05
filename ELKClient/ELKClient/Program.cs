using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELKClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Elkhelper elk = new Elkhelper();
			elk.IndexDocument();
			elk.IndexBulk();
		}
	}
}
