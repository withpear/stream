using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamTest
{
    public static class BinaryReaderTest
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public static void ReadClassUsingBinaryReader()
        {
            string path = @"..\..\..\product.txt";
            Product product = new Product() { Id = 1, Name = "CocaCola", Price = 3.5f };
            using (var stream = new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryWriter writer = new BinaryWriter(stream,Encoding.ASCII);
                writer.Write(product.Id);
                writer.Write(product.Name);
                writer.Write(product.Price);
            }

            Product product1 = new Product();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(stream);
                product1.Id = reader.ReadInt32();
                product1.Name = reader.ReadString();
                product1.Price = reader.ReadDouble();
            }

            Console.WriteLine(product1.Id);
            Console.WriteLine(product1.Name);
            Console.WriteLine(product1.Price);
        }
    }
}
