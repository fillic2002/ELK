using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ELKClient
{
	public class Elkhelper
	{
		ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"))
			.DefaultIndex("book");
		public void IndexDocument()
		{
			try
			{				
				ElasticClient client = new ElasticClient(settings);
				Book bkObj = new Book() { id=3,author = "Manjunath", name = "Finance education" };
				var s=client.IndexDocument<Book>(bkObj);
			}
			catch(Exception ex)
			{
				var s = ex.StackTrace;
			}
		}
		public void IndexBulk()
		{
		 
			IList<Book> b = new List<Book>();
			File obj = new File();
			b.Add(new Book() { id = 3, author = "ABC", name = "elastic fundamental" });
			b.Add(new Book() { id = 3, author = "DEF", name = "elastic fundamental" });
			b.Add(new Book() { id = 3, author = "GHH", name = "elastic fundamental" });

			ElasticClient client = new ElasticClient(settings);

			var bulkIndexResponse = client.Bulk(x => x
				.Index("book")
				.IndexMany(b)
				);
		}
	}

	public class Book
	{
		public int id;
		public string name;
		public string author;
	}
}
