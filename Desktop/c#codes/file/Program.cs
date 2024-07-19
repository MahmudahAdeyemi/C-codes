// // See https://aka.ms/new-console-template for more information
// using file.Entities;
// using file.Implementation.Repositories;
// using file.Implementation.Services;
// using file.RequestModel;

// // Console.WriteLine("Hello, World!");

// var basePath = "c:\\StockManagementData";
// var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
// var productService = new ProductService(productRepository);

// var createProductRequestModel = new ProductRequestModel{
//     Name = "Turkey",
//     Description = "Turkey",
//     Price = 4000,
//     QuantityAvailable = 50,
//     UnitOfMeasurement = file.Entities.Measurement.Kg
// };

// var userName = "admin";
// var pasword = "something";
// var userRepo = new UserRepository();
// AuthService authService = new AuthService(userRepo);
// var result = authService.Login(userName, pasword);

// if(result){
//      var response = productService.AddProduct(createProductRequestModel);
using file;

Menu menu  = new Menu();
menu.MainMenu ();
// Console.WriteLine(admin.Name);