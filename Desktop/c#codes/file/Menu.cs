
using file.Implementation.Repositories;
using file.Implementation.Services;
using file.Interfaces.Repositoritories;
using file.RequestModel;

namespace file
{
    public class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("Welcome\nEneter \n 1 to register \n 2 to login \n3 to cgange pasword \n4 to view all product\n5 to get product by name\n6 to add product\n7 to update product \n8 to make order");
            int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    RegisterMenu();
                    break;
                    case 2:
                    LoginMenu();
                    break;
                    case 3:
                    ChangePasswordMenu();
                    break;
                    case 4:
                    ViewAllProduct();
                    break;
                    case 5:
                    GetProduct();
                    break;
                    case 6:
                    AddProduct();
                    break;
                    case 7:
                    UpdateProduct();
                    break;
                    case 8:
                    CreateOrder();
                    break;
                }
        }
        public void RegisterMenu()
        {
            var customerRequestModel = new CustomerRequestModel();
            Console.Write("Enter your name: ");
            customerRequestModel.Name = Console.ReadLine();
            Console.Write("Enter your email: ");
            customerRequestModel.Email = Console.ReadLine();
            Console.Write("Enter your password: ");
            customerRequestModel.Password = Console.ReadLine();
            Console.Write("Enter your address: ");
            customerRequestModel.Address = Console.ReadLine();
            var basePath = "c:\\StockManagementData";
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var userRepository = new UserRepository(Path.Combine(basePath,"user.json"));
            var customerService = new CustomerService(customerRepository, userRepository);
            Console.WriteLine(customerService.Register(customerRequestModel).Message);
            MainMenu();
            
        }
        public void LoginMenu()
        {
            var loginRequestModel = new LoginRequestModel();
            Console.Write("Enter your name: ");
            loginRequestModel.UserName = Console.ReadLine();
            Console.Write("Enter your password: ");
            loginRequestModel.Password = Console.ReadLine();
            var basePath = "c:\\StockManagementData";
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var userRepository = new UserRepository(Path.Combine(basePath,"user.json"));
            var customerService = new CustomerService(customerRepository, userRepository);
            Console.WriteLine(customerService.Login(loginRequestModel).Message);
            MainMenu();
        }
        public void ChangePasswordMenu()
        {
            var changePasswordRequest = new ChangePasswordRequest();
            Console.Write("Enter the previous password: ");
            changePasswordRequest.OldPassword = Console.ReadLine();
            Console.WriteLine("Enter the new password: ");
            changePasswordRequest.NewPassword = Console.ReadLine(); 
            var basePath = "c:\\StockManagementData";
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var userRepository = new UserRepository(Path.Combine(basePath,"user.json"));
            var customerService = new CustomerService(customerRepository, userRepository);
            Console.WriteLine(customerService.ChangePassword(changePasswordRequest).Message);
            MainMenu();
        }
        public void ViewAllProduct()
        {
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var productService = new ProductService(productRepository);
            Console.WriteLine($" Name        Price       Quantity");
            foreach (var item in productService.GetAllProductResponse().Data)
            {
                Console.WriteLine($"{item.Name}   {item.Price}   {item.QuantityAvailable} \n");
            }
            MainMenu();
        }
        public void GetProduct()
        {
            Console.WriteLine("Enter the name of the product:  ");
            string name = Console.ReadLine();
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var productService = new ProductService(productRepository);
            var product = productService.GetProductById(name);
            Console.WriteLine($"The name is {product.Data.Name}");
            Console.WriteLine($"The price is {product.Data.Price}");
            Console.WriteLine($"The quantity available is {product.Data.QuantityAvailable}");
        }
        public void AddProduct()
        {

            var productRequestModel = new ProductRequestModel();
            Console.Write("Enter the name of the product: ");
            productRequestModel.Name = Console.ReadLine();
            Console.Write("Enter the selling price of the product: ");
            productRequestModel.SellingPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter the cost price of the product: ");
            productRequestModel.CostPrice = int.Parse(Console.ReadLine());
            Console.Write("Describe the product: ");
            productRequestModel.Description = Console.ReadLine();
            Console.Write("Enter the quantity: ");
            productRequestModel.QuantityAvailable = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the unit of measurement \n1 for kg \n2 for litre");
            int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    productRequestModel.UnitOfMeasurement = Entities.Measurement.Kg;
                    break;
                    case 2:
                    productRequestModel.UnitOfMeasurement = Entities.Measurement.Litre;
                    break;
                }
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var productService = new ProductService(productRepository);
            var product = productService.AddProduct(productRequestModel);
            Console.WriteLine(product.Message);
            MainMenu();

        }
        public void UpdateProduct()
        {

            var productRequestModel = new ProductRequestModel();
            Console.Write("Enter the name of the product: ");
            productRequestModel.Name = Console.ReadLine();
            Console.Write("Enter the selling price of the product: ");
            productRequestModel.SellingPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter the cost price of the product: ");
            productRequestModel.CostPrice = int.Parse(Console.ReadLine());
            Console.Write("Describe the product: ");
            productRequestModel.Description = Console.ReadLine();
            Console.Write("Enter the quantity: ");
            productRequestModel.QuantityAvailable = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the unit of measurement \n1 for kg \n2 for litre");
            int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    productRequestModel.UnitOfMeasurement = Entities.Measurement.Kg;
                    break;
                    case 2:
                    productRequestModel.UnitOfMeasurement = Entities.Measurement.Litre;
                    break;
                }
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var productService = new ProductService(productRepository);
            var product = productService.UpdateProduct(productRequestModel);
            Console.WriteLine(product.Message);
            MainMenu();
        }
        public void CreateOrder()
        {
            var orderRequest = new OrderRequestModel();
            int result = 0;
            while(result != 2)
            {
                UnitOrder unitOrder = new UnitOrder();
                Console.WriteLine("Enter tne name of the product:  ");
                unitOrder.Product = Console.ReadLine();
                Console.Write("Enter the quantity:  ");
                unitOrder.Quantity = int.Parse(Console.ReadLine());
                orderRequest.Orders.Add(unitOrder);
                Console.WriteLine("Enter\n1 to add more product \n2 to quit");
                result = int.Parse(Console.ReadLine());
                

            }
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var orderRepository = new OrderRepository(Path.Combine(basePath,"product.json"));
            var orderService = new OrderService(orderRepository,productRepository,customerRepository);
            var response=orderService.MakeOrder(orderRequest);
            Console.WriteLine(response.Message);
            MainMenu();
        }
        public void CancelOrder()
        {
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var orderRepository = new OrderRepository(Path.Combine(basePath,"product.json"));
            var orderService = new OrderService(orderRepository,productRepository,customerRepository);
            var response = orderService.Cancel();
            Console.WriteLine(response.Message);
            
            MainMenu();
        }
        public void MakePayment()
        {
            Console.Write("Enter the amount in your wallet: ");
            double amount = int.Parse(Console.ReadLine());
            var basePath = "c:\\StockManagementData";
            var productRepository = new ProductRepository(Path.Combine(basePath,"product.json"));
            var customerRepository = new CustomerRepository(Path.Combine(basePath,"customer.json"));
            var orderRepository = new OrderRepository(Path.Combine(basePath,"product.json"));
            var orderService = new OrderService(orderRepository,productRepository,customerRepository);
            var response = orderService.Pay(amount);
            Console.WriteLine(response.Message);
            MainMenu();
        }

    }
}