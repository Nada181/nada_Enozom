using TodoApi.Models;
using System;
using System.Linq;
using TodoApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 //Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


namespace TodoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CommerceContext())
            {

               
               Console.WriteLine($"Database path: {db.DbPath}.");

                // Create
                Console.WriteLine("Inserting a new product");
                db.Add(new Product {ProductName= "HP Laptop 15" , IsComplete=true , ProductCategories ="HP"});
                db.Add(new Product { ProductName = "iphone 15", IsComplete = true, ProductCategories = "Apple" });
                db.Add(new Product { ProductName = "Samsung s32", IsComplete = true, ProductCategories = "Samsung" });
                db.Add(new Product { ProductName = "Samsung  LED Screen 32", IsComplete = true, ProductCategories = "Apple" });
                db.SaveChanges();

                // Read
                //Console.WriteLine("Querying for a blog");
                //var product = db.products.Find(1);



                // Update , find the blog first then add the post of blog number ...
                //Console.WriteLine("Updating the blog and adding a post");

                //Product.Categories.Add(
                //new categories { ProductCategories = "Apple"});
                //db.SaveChanges();

                // Delete , find it first then delete
                //Console.WriteLine("Delete the product");
                //db.Remove(product);
                //db.SaveChanges();
            }
        }
    }
}



