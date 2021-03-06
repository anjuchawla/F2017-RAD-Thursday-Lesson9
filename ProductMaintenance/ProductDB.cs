﻿//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace ProductMaintenance
//{
//    public static class ProductDB
//    {
//       private const string dir = @"C:\C# 2015\Files\";
//        private const string path = @"..\..\Products.txt"; //dir + "Products.txt";

//        public static List<Product> GetProducts()
//        {
//            List<Product> products = new List<Product>();
//            Product product;
//            StreamReader textIn = null ;

//            try
//            {
//                // if the directory doesn't exist, create it
//                if (!Directory.Exists(dir))
//                    Directory.CreateDirectory(dir);

//                // create the object for the input stream for a text file
//                textIn =
//                   new StreamReader(
//                   new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));



//                // read the data from the file and store it in the list
//                while (textIn.Peek() != -1)
//                {
//                    string row = textIn.ReadLine();
//                    string[] columns = row.Split('|');
//                    product = new Product();
//                    product.Code = columns[0];
//                    product.Description = columns[1];
//                    product.Price = Convert.ToDecimal(columns[2]);
//                    products.Add(product);
//                }
//                return products;
//            }
            
//            catch (IOException ex)
//            {
//                MessageBox.Show(ex.Message, "Input/Output Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            finally {
//                // close the input stream for the text file
//                if(textIn != null)
//                    textIn.Close();
//            }

//            return products;
//        }

//        public static void SaveProducts(List<Product> products)
//        {

//            StreamWriter textOut = null;
//            // create the output stream for a text file that exists
//            try
//            {
//                textOut =
//                    new StreamWriter(
//                    new FileStream(path, FileMode.Create, FileAccess.Write));

//                // write each product
//                foreach (Product product in products)
//                {
//                    textOut.Write(product.Code + "|");
//                    textOut.Write(product.Description + "|");
//                    textOut.WriteLine(product.Price);
//                }
//            }
//            catch(IOException ex)
//            {
//                MessageBox.Show(ex.Message, "Input/Output Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            finally
//            {
//                if(textOut != null)
//                    textOut.Close();
//            }
//            // close the output stream for the text file
            
//        }
//    }
//}



 using System;
using System.IO;
using System.Collections.Generic;

namespace ProductMaintenance
{
    public class ProductDB
	{
		private const string dir = @"C:\C# 2015\Files\";
        private const string path = @"..\..\Products.dat"; // dir + "Products.dat";

		public static List<Product> GetProducts()
		{
			// if the directory doesn't exist, create it
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			// create the object for the input stream for a binary file
			BinaryReader binaryIn = 
				new BinaryReader(
				new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

			// create the array list
			List<Product> products = new List<Product>();

			// read the data from the file and store it in the List<Product>
			while (binaryIn.PeekChar() != -1)
			{
				Product product = new Product();
				product.Code = binaryIn.ReadString();
				product.Description = binaryIn.ReadString();
				product.Price = binaryIn.ReadDecimal();
				products.Add(product);
			}

			// close the input stream for the binary file
			binaryIn.Close();

			return products;
		}

		public static void SaveProducts(List<Product> products)
		{
			// create the output stream for a binary file that exists
			BinaryWriter binaryOut = 
				new BinaryWriter(
				new FileStream(path, FileMode.Create, FileAccess.Write));

			// write each product
			foreach (Product product in products)
			{
				binaryOut.Write(product.Code);
				binaryOut.Write(product.Description);
				binaryOut.Write(product.Price);
			}

			// close the output stream
			binaryOut.Close();
	   }
	}
}
