using Transaction.DTO;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
using Transaction.ResponseModel;
namespace Transaction.Implementation.Services
{
    public class SalesService : ISalesService
    {
        private readonly IOpeningStockRepository _openingStockRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepRepository _salesRepRepository;
        private readonly IShopItemsRepository _shopItemsRepository;
        private readonly IGoodRealesdRepository _goodRealesdRepository;
        private readonly IGoodReturnedRepository _goodReturnedRepository;
        private readonly ICashRepository _cashRepository;
        private readonly IValidClosingStockRepository _validClosingStockRepository;

        public SalesService(IOpeningStockRepository openingStockRepository, ISalesRepository salesRepository, IProductRepository productRepository, ISalesRepRepository salesRepRepository, IShopItemsRepository shopItemsRepository, IGoodRealesdRepository goodRealesdRepository, IGoodReturnedRepository goodReturnedRepository, ICashRepository cashRepository, IValidClosingStockRepository validClosingStockRepository)
        {
            _openingStockRepository = openingStockRepository;
            _salesRepository = salesRepository;
            _productRepository = productRepository;
            _salesRepRepository = salesRepRepository;
            _shopItemsRepository = shopItemsRepository;
            _goodRealesdRepository = goodRealesdRepository;
            _goodReturnedRepository = goodReturnedRepository;
            _cashRepository = cashRepository;
            _validClosingStockRepository = validClosingStockRepository;
        }

        public SalesResponseModel GetAllPurchase()
        {

            var purchaces = _salesRepository.GetAllSales();
            if (purchaces == null)
            {
                return new SalesResponseModel
                {
                    Status = false,
                    Message = "No Purchase retrieved"
                };
            }
            var purchacesReturned = purchaces.Select(sr => new SalesDTO
            {
                Id = sr.Id,
                TimeOfTransaction = sr.TimeOfTransaction,
                TotalPrice = Math.Round(sr.TotalPrice,2),
                PaymentStatus = sr.PaymentStatus.ToString(),
                SalesRep = _salesRepRepository.GetSalesRepById(sr.SalesRepId).FirstName
            }).ToList();

            return new SalesResponseModel
            {
                Data = purchacesReturned,
                Message = "",
                Status = true
            };
        }
        public SalesResponse GetPurchaseById(int id)
        {
            var manager = _salesRepository.GetSalesById(id);
            if (manager == null)
            {
                return new SalesResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            List<string> ProductName = new List<string>();
            List<decimal> ProductPrice = new List<decimal>();
            List<decimal> ProductQuantity = new List<decimal>();
            decimal TotalPrice = 0;
            for (int i = 0; i < manager.SalesProducts.Count(); i++)
            {
                var product1 = _productRepository.GetProductById(manager.SalesProducts[i].ProductId);
                Product product = new Product
                {
                    Name = product1.Name
                };
                ProductName.Add(product.Name);
                ProductPrice.Add(Math.Round(manager.SalesProducts[i].ProductQuantities,2));
                ProductQuantity.Add(Math.Round(manager.SalesProducts[i].ProductQuantities,2));
                decimal total = manager.SalesProducts[i].ProductQuantities * product1.UnitPrice;
                TotalPrice += total;
            }
            var salesRep = _salesRepRepository.GetSalesRepById(manager.SalesRepId);
            return new SalesResponse
            {
                Data = new SalesDTO
                {
                    Id = manager.Id,
                    TimeOfTransaction = manager.TimeOfTransaction,
                    TotalPrice = Math.Round(TotalPrice,2),
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    SalesRep = salesRep.FirstName + "  " + salesRep.LastName,
                    PaymentStatus = manager.PaymentStatus.ToString()

                },
                Message = "Sucessfully done.",
                Status = true
            };
        }
        public DecimalResponseModel AddSales(SalesRequestModel salesRequestModel, int SalesRepId)
        {
            if (_openingStockRepository.GetAllOpeningStock().Count() == 0)
            { 
                List<string> ProductName = new List<string>();
                List<decimal> Quantity = new List<decimal>();
                OpeningStock openingStock = new OpeningStock
                {
                    Date = DateTime.Now
                };
                for (int i = 0; i < _shopItemsRepository.GetAllShopItems().Count(); i++)
                {
                    var product = _productRepository.GetAllProduct().Single(x => x.Name == _shopItemsRepository.GetAllShopItems()[i].Name);
                    OpeningStockProduct openingStockProduct = new OpeningStockProduct
                    {
                        ProductId = product.Id,
                        Quantity = Math.Round(_shopItemsRepository.GetAllShopItems()[i].Quantity,2)
                    };
                    openingStock.OpeningStockProducts.Add(openingStockProduct);
                }
                _openingStockRepository.AddOpeningStock(openingStock);
            }
            else if (_openingStockRepository.GetAllOpeningStock().Last().Date.Day != DateTime.Now.Day &&_openingStockRepository.GetAllOpeningStock().Last().Date.Month != DateTime.Now.Month && _openingStockRepository.GetAllOpeningStock().Last().Date.Year != DateTime.Now.Year)
            {
                List<string> ProductName = new List<string>();
                List<decimal> Quantity = new List<decimal>();
                OpeningStock openingStock = new OpeningStock
                {
                    Date = DateTime.Now
                };
                for (int i = 0; i < _shopItemsRepository.GetAllShopItems().Count(); i++)
                {
                    var product = _productRepository.GetAllProduct().Single(x => x.Name == _shopItemsRepository.GetAllShopItems()[i].Name);
                    OpeningStockProduct openingStockProduct = new OpeningStockProduct
                    {
                        ProductId = product.Id,
                        Quantity = _shopItemsRepository.GetAllShopItems()[i].Quantity
                    };
                    openingStock.OpeningStockProducts.Add(openingStockProduct);
                }
                _openingStockRepository.AddOpeningStock(openingStock);
            }
            List<string> shopItemsNames = new List<string>();
            decimal potalPrice = 0;
            Sales sales = new Sales
            {
                TimeOfTransaction = DateTime.Now,
                SalesRepId = SalesRepId,
                PaymentStatus = salesRequestModel.PaymentStatus
            };
            for (int i = 0; i < salesRequestModel.ProductId.Count(); i++)
            {
                var product = _productRepository.GetProductById(salesRequestModel.ProductId[i]);
                SalesProduct salesProduct = new SalesProduct
                {
                    SalesId = sales.Id,
                    ProductId = salesRequestModel.ProductId[i],
                    ProductQuantities = Math.Round(salesRequestModel.ProductQuantity[i],2)
                }; 
                Product product1 = _productRepository.GetProductById(salesRequestModel.ProductId[i]);
                if (product1.CategoryQuantity != null  )
                {
                    if (salesProduct.ProductQuantities < product1.CategoryQuantity/2)
                    {
                        decimal total = product.UnitPrice * salesProduct.ProductQuantities;
                        potalPrice += total;
                    }
                    else
                    {
                        decimal r = Math.Round(salesProduct.ProductQuantities % ((decimal)product.CategoryQuantity/2),2);
                        decimal price =Math.Round( product.UnitPrice * r,2);
                        potalPrice += price;
                        decimal ty =Math.Round( (salesProduct.ProductQuantities - r) * (decimal)product.CategoryPrice,2);
                        potalPrice += ty;
                    }
                }
                else
                {
                    decimal total = Math.Round(product.UnitPrice * salesProduct.ProductQuantities,2);
                    potalPrice += total;
                }
                sales.SalesProducts.Add(salesProduct);
            }
            sales.TotalPrice = Math.Round(potalPrice,2);
            _salesRepository.AddSales(sales);

            for (int i = 0; i < salesRequestModel.ProductId.Count(); i++)
            {
                var product = _productRepository.GetProductById(salesRequestModel.ProductId[i]);
                shopItemsNames = _shopItemsRepository.GetAllShopItems().Select(d => d.Name).ToList();
                ShopItems shopItems = new ShopItems
                {
                    Name = product.Name,
                    Quantity = Math.Round(salesRequestModel.ProductQuantity[i],2)
                };
                var storeItem1 = _shopItemsRepository.GetAllShopItems().SingleOrDefault(x => x.Name == shopItems.Name);
                storeItem1.Quantity -= shopItems.Quantity;
                _shopItemsRepository.UpdateShopItems(storeItem1);
            }
            return new DecimalResponseModel
            {
                Data = new DecimalDTO
                {
                    AmountLeft =Math.Round( potalPrice,2)
                },
                Message = "Sucessfully done",
                Status = true
            };
        }
        public SalesResponseModel GetSalesRepThatSoldGood(string FirstName, string LastName)
        {
            var salesRep = _salesRepRepository.GetSalesRepByName(FirstName, LastName);
            var sales = _salesRepository.GetAllSales().Where(x => x.SalesRepId == salesRep.Id);
            List<SalesDTO> salesDTOs = new List<SalesDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.SalesProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.SalesProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _salesRepository.GetSalesById(item.SalesProducts[i].SalesId);
                    ProductQuantity.Add(Math.Round(sale.SalesProducts[i].ProductQuantities,2));
                }
                SalesDTO salesDTO = new SalesDTO
                {
                    Id = item.Id,
                    TimeOfTransaction = item.TimeOfTransaction,
                    TotalPrice = Math.Round(item.TotalPrice,2),
                    SalesRep = _salesRepRepository.GetSalesRepById(item.SalesRepId).FirstName,
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    PaymentStatus = item.PaymentStatus.ToString()
                };
                salesDTOs.Add(salesDTO);
            }
            return new SalesResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public SalesResponseModel GetSalesInRange(DateTime InitialDate, DateTime LatstDate)
        {
            var sales = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.Day <= LatstDate.Day && x.TimeOfTransaction.Day >= InitialDate.Day && x.TimeOfTransaction.Month == LatstDate.Month && x.TimeOfTransaction.Year== LatstDate.Year).ToList();
            if (sales == null)
            {
                return new SalesResponseModel
                {
                    Message = " ",
                    Status = false
                };
            }
            List<SalesDTO> salesDTOs = new List<SalesDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.SalesProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.SalesProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _salesRepository.GetSalesById(item.SalesProducts[i].SalesId);
                    ProductQuantity.Add(Math.Round(sale.SalesProducts[i].ProductQuantities,2));
                }
                SalesDTO salesDTO = new SalesDTO
                {
                    Id = item.Id,
                    TimeOfTransaction = item.TimeOfTransaction,
                    TotalPrice = Math.Round(item.TotalPrice,2),
                    SalesRep = _salesRepRepository.GetSalesRepById(item.SalesRepId).FirstName,
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    PaymentStatus = item.PaymentStatus.ToString()
                };
                salesDTOs.Add(salesDTO);
            }
            return new SalesResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public GoodReleasedsResponse GetGoodReleasedsPerDay(DateTime Date)
        {
            var sales = _goodRealesdRepository.GetAllGoodReleased().Where(x => x.DateReleased.Month == Date.Month && x.DateReleased.Day == Date.Day && x.DateReleased.Year == Date.Year);
            List<GoodRealeasedDTO> salesDTOs = new List<GoodRealeasedDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();  
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.GoodReleasedProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.GoodReleasedProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _goodRealesdRepository.GetGoodReleasedById(item.GoodReleasedProducts[i].GoodReleasedId);
                    ProductQuantity.Add(Math.Round(sale.GoodReleasedProducts[i].Quantity,2));
                }
                var salesDTO = new GoodRealeasedDTO
                {
                    Id = item.Id,
                    DateReleased = item.DateReleased,
                    ProductName = ProductName,
                    Quantity = ProductQuantity
                };
                salesDTOs.Add(salesDTO);
            }
            return new GoodReleasedsResponse
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public SalesResponseModel GetSalesByPaymentStatusAndDate(PaymentStatus paymentStatus, DateTime Date)
        {
            var sales = _salesRepository.GetAllSales().Where(x => x.PaymentStatus == paymentStatus && x.TimeOfTransaction.Day == Date.Day && x.TimeOfTransaction.Year == Date.Year && x.TimeOfTransaction.Month == Date.Month);
            List<SalesDTO> salesDTOs = new List<SalesDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.SalesProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.SalesProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _salesRepository.GetSalesById(item.SalesProducts[i].SalesId);
                    ProductQuantity.Add(sale.SalesProducts[i].ProductQuantities);
                }
                SalesDTO salesDTO = new SalesDTO
                {
                    Id = item.Id,
                    TimeOfTransaction = item.TimeOfTransaction,
                    TotalPrice = item.TotalPrice,
                    SalesRep = _salesRepRepository.GetSalesRepById(item.SalesRepId).FirstName,
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    PaymentStatus = item.PaymentStatus.ToString()
                };
                salesDTOs.Add(salesDTO);
            }
            return new SalesResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public GoodReturnedsResponseModel GetGoodReturnedPerDay(DateTime Date)
        {
            var sales = _goodReturnedRepository.GetAllGoodsReturned().Where(x => x.DateReleased.Day == Date.Day &&  x.DateReleased.Month == Date.Month &&  x.DateReleased.Year == Date.Year);
            List<GoodReturnedDTO> salesDTOs = new List<GoodReturnedDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.GoodsReturnedProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.GoodsReturnedProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _goodReturnedRepository.GetGoodsReturnedById(item.GoodsReturnedProducts[i].GoodsReturnedId);
                    ProductQuantity.Add(Math.Round(sale.GoodsReturnedProducts[i].Quantity,2));
                }
                var salesDTO = new GoodReturnedDTO
                {
                    Id = item.Id,
                    DateReleased = item.DateReleased,
                    ProductName = ProductName,
                    Quantity = ProductQuantity
                };
                salesDTOs.Add(salesDTO);
            }
            return new GoodReturnedsResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public ShopItemResponse GetOpeningSock(DateTime dateTime)
        {
            var shopItem = _openingStockRepository.GetAllOpeningStock().SingleOrDefault(x => x.Date.Day == dateTime.Day && x.Date.Month == dateTime.Month && x.Date.Year == dateTime.Year);
            var validClosingStock = _validClosingStockRepository.GetAllValidClosingStock().SingleOrDefault(x => x.Date.AddDays(1) == dateTime);
            if (shopItem == null && validClosingStock != null)
            {
                
                OpeningStock openingStock = new OpeningStock
                {
                    Date = dateTime
                };
                for (int i = 0; i < validClosingStock.ValidClosingStockProducts.Count(); i++)
                {
                    OpeningStockProduct openingStockProduct = new OpeningStockProduct
                    {
                        ProductId = validClosingStock.ValidClosingStockProducts[i].ProductId,
                        Quantity = Math.Round(validClosingStock.ValidClosingStockProducts[i].Quantities,2)
                    };
                    openingStock.OpeningStockProducts.Add(openingStockProduct);
                }
                shopItem = openingStock;
                
            }
            else if(validClosingStock == null && shopItem == null)
            {
                var newdate = dateTime.AddDays(-1);
                var closigstock = GetClosingSock(newdate);
                OpeningStock openingStock = new OpeningStock
                {
                    Date = dateTime
                };
                for (int i = 0; i < closigstock.Data.Count(); i++)
                {
                    OpeningStockProduct openingStockProduct = new OpeningStockProduct
                    {
                        ProductId = _productRepository.GetAllProduct().Single(x => x.Name == closigstock.Data[i].Name).Id,
                        Quantity = closigstock.Data[i].Quantity
                    };
                    openingStock.OpeningStockProducts.Add(openingStockProduct);
                }
                shopItem = openingStock;
                
            }
            
            // var sales = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.Day >= dateTime.Day);
            // var shopItems = _shopItemsRepository.GetAllShopItems();
            // foreach (var item in shopItems)
            // {
            //     foreach (var sale in sales)
            //     {
            //         for (int i = 0; i < sale.SalesProducts.Count(); i++)
            //         {
            //             Product product = _productRepository.GetProductById(sale.SalesProducts[i].ProductId);
            //             if (item.Name == product.Name)
            //             {
            //                 item.Quantity = item.Quantity + sale.SalesProducts[i].ProductQuantities;
            //             }
            //         }
            //     }
            //     var goodReturneds = _goodReturnedRepository.GetAllGoodsReturned().Where(x => x.DateReleased.Day >= dateTime.Day);
            //     foreach (var goodReturned in goodReturneds)
            //     {
            //         for (int i = 0; i < goodReturned.GoodsReturnedProducts.Count(); i++)
            //         {
            //             Product product = _productRepository.GetProductById(goodReturned.GoodsReturnedProducts[i].ProductId);
            //             if (product.Name == item.Name)
            //             {
            //                 item.Quantity += goodReturned.GoodsReturnedProducts[i].Quantity;
            //             }
            //         }
            //     }
            //     var goodReleaseds = _goodRealesdRepository.GetAllGoodReleased().Where(x => x.DateReleased.Day >= dateTime.Day);
            //     foreach (var goodReleased in goodReleaseds)
            //     {
            //         for (int i = 0; i < goodReleased.GoodReleasedProducts.Count(); i++)
            //         {
            //             Product product = _productRepository.GetProductById(goodReleased.GoodReleasedProducts[i].ProductId);
            //             if (product.Name == item.Name)
            //             {
            //                 item.Quantity -= goodReleased.GoodReleasedProducts[i].Quantity;
            //             }
            //         }
            //     }
            // }
            // decimal Total = 0;
            // foreach (var item in shopItems)
            // {
            //     Product product = _productRepository.GetAllProduct().Single(x => x.Name == item.Name);
            //     decimal total = item.Quantity * product.UnitPrice;
            //     Total += total;
            // }
            List<ShopItemDTO> shopItemDTOs = new List<ShopItemDTO>();
            for (int i = 0; i < shopItem.OpeningStockProducts.Count(); i++)
            {
                ShopItemDTO shopItemDTO = new ShopItemDTO
                {
                    Id = shopItem.OpeningStockProducts[i].OpeningStockId,
                    Name = _productRepository.GetProductById(shopItem.OpeningStockProducts[i].ProductId).Name,
                    Quantity = Math.Round(shopItem.OpeningStockProducts[i].Quantity,2)
                };
                shopItemDTOs.Add(shopItemDTO);
            }
            // var purchacesReturned = shopItem.OpeningStockProducts.Select(sr => new ShopItemDTO
            // {
            //     Id = sr.Id,
            //     Name = _productRepository.GetAllProduct().Single(x => x.Id == sr.Id).Name,
            //     Quantity = sr.Quantity
            // }).ToList();

            return new ShopItemResponse
            {
                Data = shopItemDTOs,
                Message = "",
                Status = true
            };
        }
        public ShopItemResponse GetClosingSock(DateTime dateTime)
        {
            var sales = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.Day > dateTime.Day);
            var shopItems = _shopItemsRepository.GetAllShopItems();
            var validClosingStocks = _validClosingStockRepository.GetAllValidClosingStock().SingleOrDefault(x => x.Date.Day == dateTime.Day && x.Date.Month == dateTime.Month && x.Date.Year == dateTime.Year);
            var openingStocks = _openingStockRepository.GetAllOpeningStock().SingleOrDefault(x => x.Date.Day == dateTime.Day &&x.Date.Month == dateTime.Month && x.Date.Year == dateTime.Year);
            foreach (var item in shopItems)
            {
                // foreach (var sale in sales)
                // {
                //     for (int i = 0; i < sale.SalesProducts.Count(); i++)
                //     {
                //         Product product = _productRepository.GetProductById(sale.SalesProducts[i].ProductId);
                //         if (item.Name == product.Name)
                //         {
                //             item.Quantity = item.Quantity + sale.SalesProducts[i].ProductQuantities;
                //         }
                //     }
                // }
                // var goodReturneds = _goodReturnedRepository.GetAllGoodsReturned().Where(x => x.DateReleased.Day > dateTime.Day);
                if (validClosingStocks != null)
                {
                    for (int i = 0; i < validClosingStocks.ValidClosingStockProducts.Count(); i++)
                    {
                        var product = _productRepository.GetProductById(validClosingStocks.ValidClosingStockProducts[i].ProductId);
                        if (product.Name == item.Name)
                        {
                            item.Quantity = Math.Round(validClosingStocks.ValidClosingStockProducts[i].Quantities,2);
                        }
                    }
                }
                else
                {
                    
                    var sale = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.DayOfYear <= dateTime.DayOfYear && x.TimeOfTransaction.Year <= dateTime.Year).ToList();
                    if (sale != null)
                    {
                        var goodReleaseds = GetGoodReleasedsPerDay(dateTime);
                        foreach (var goodReleased in goodReleaseds.Data)
                        {
                            for (int i = 0; i < goodReleased.ProductName.Count(); i++)
                            {
                                var product = _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.ProductName[i]);
                                var name = openingStocks.OpeningStockProducts.Select(x => x.ProductId).ToList();
                                if (!(name.Contains(product.Id)))
                                {
                                    OpeningStockProduct openingStockProduct = new OpeningStockProduct
                                    {
                                        ProductId = _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.ProductName[i]).Id,
                                        Quantity = Math.Round(goodReleased.Quantity[i],2)
                                    };
                                    openingStocks.OpeningStockProducts.Add(openingStockProduct);
                                }
                                else
                                {
                                    foreach (var open in openingStocks.OpeningStockProducts)
                                    {
                                        if (open.ProductId ==  _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.ProductName[i]).Id)
                                        {
                                            open.Quantity +=Math.Round(goodReleased.Quantity[i],2);
                                        }
                                    }
                                }
                            }
                        }
                        var goodReturned = GetGoodReturnedPerDay(dateTime);
                        foreach (var goodReleased in goodReturned.Data)
                        {
                            for (int i = 0; i < goodReleased.ProductName.Count(); i++)
                            {
                                var product = _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.ProductName[i]);
                                var name = openingStocks.OpeningStockProducts.Select(x => x.ProductId).ToList();
                                
                                foreach (var open in openingStocks.OpeningStockProducts)
                                {
                                    if (open.ProductId ==  _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.ProductName[i]).Id)
                                    {
                                        open.Quantity -=Math.Round( goodReleased.Quantity[i],2);
                                    }
                                }
                                
                            }
                        }
                        foreach (var openingStock in openingStocks.OpeningStockProducts)
                        {
                            for (int i = 0; i < sale.Count(); i++)
                            {
                                for (int j = 0; j < sale[i].SalesProducts.Count(); j++)
                                {
                                    if (openingStock.ProductId == sale[i].SalesProducts[j].ProductId)
                                    {
                                        openingStock.Quantity -= Math.Round(sale[i].SalesProducts[j].ProductQuantities,2);
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                // foreach (var goodReturned in goodReturneds)
                // {
                //     for (int i = 0; i < goodReturned.GoodsReturnedProducts.Count(); i++)
                //     {
                //         Product product = _productRepository.GetProductById(goodReturned.GoodsReturnedProducts[i].ProductId);
                //         if (product.Name == item.Name)
                //         {
                //             item.Quantity += goodReturned.GoodsReturnedProducts[i].Quantity;
                //         }
                //     }
                // }
                // var goodReleaseds = _goodRealesdRepository.GetAllGoodReleased().Where(x => x.DateReleased.Day > dateTime.Day);
                // foreach (var goodReleased in goodReleaseds)
                // {
                //     for (int i = 0; i < goodReleased.GoodReleasedProducts.Count(); i++)
                //     {
                //         Product product = _productRepository.GetProductById(goodReleased.GoodReleasedProducts[i].ProductId);
                //         if (product.Name == item.Name)
                //         {
                //             item.Quantity -= goodReleased.GoodReleasedProducts[i].Quantity;
                //         }
                //     }
                // }
            }
            decimal Total = 0;
            foreach (var item in shopItems)
            {
                Product product = _productRepository.GetAllProduct().SingleOrDefault(x => x.Name == item.Name);
                decimal total = item.Quantity * product.UnitPrice;
                Total += total;
            }
            List<ShopItemDTO> purchacesReturned;
            if (validClosingStocks != null || openingStocks != null)
            {
                if (validClosingStocks != null)
                {
                    purchacesReturned = shopItems.Select(sr => new ShopItemDTO
                    {
                        Id = sr.Id,
                        Name = sr.Name,
                        Quantity = Math.Round(sr.Quantity,2)
                    }).ToList();   
                }
                else
                {
                    purchacesReturned = openingStocks.OpeningStockProducts.Select(sr => new ShopItemDTO
                    {
                        Id = sr.Id,
                        Name = _productRepository.GetAllProduct().Single(x => x.Id == sr.ProductId).Name,
                        Quantity = Math.Round(sr.Quantity,2)
                    }).ToList();
                }
                
                return new ShopItemResponse
                {
                    Data = purchacesReturned,
                    Message = "",
                    Status = true
                };
            }
            

            return new ShopItemResponse
            {
                Data = null,
                Message = " ",
                Status = false
            };
        }
        public SalesResponseModel GetSalesInADay()
        {
            DateTime Date = DateTime.Now;
            var sales = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.Day == Date.Day).ToList();
            if (sales == null)
            {
                return new SalesResponseModel
                {
                    Message = " ",
                    Status = false
                };
            }
            List<SalesDTO> salesDTOs = new List<SalesDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.SalesProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.SalesProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _salesRepository.GetSalesById(item.SalesProducts[i].SalesId);
                    ProductQuantity.Add(Math.Round(sale.SalesProducts[i].ProductQuantities,2));
                }
                var salesDTO = new SalesDTO
                {
                    Id = item.Id,
                    TimeOfTransaction = item.TimeOfTransaction,
                    TotalPrice = item.TotalPrice,
                    SalesRep = _salesRepRepository.GetSalesRepById(item.SalesRepId).FirstName,
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    PaymentStatus = item.PaymentStatus.ToString()
                };
                salesDTOs.Add(salesDTO);
            }
            return new SalesResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
        public DecimalResponseModel CheckAccount(DateTime Date,string FirstName,string LastName)
        {
            var sales = _salesRepository.GetAllSales().Where(x => x.SalesRepId == _salesRepRepository.GetSalesRepByName(FirstName,LastName).Id && x.PaymentStatus == PaymentStatus.Cash);
            decimal TotalPrice = 0;
            foreach (var item in sales)
            {
                TotalPrice += item.TotalPrice;
            }
            var sale = _cashRepository.GetAllCash().Last(x => x.SalesRepId == _salesRepRepository.GetSalesRepByName(FirstName,LastName).Id);
            if (TotalPrice > sale.CashToBeSubmitted)
            {
                return new DecimalResponseModel
                {
                    Data = new DecimalDTO
                    {
                        AmountLeft = TotalPrice - sale.CashToBeSubmitted,
                    },
                    Message = $"Account not balanced {TotalPrice - sale.CashToBeSubmitted} left",
                    Status = false
                };
            }
            else if(sale.CashToBeSubmitted > TotalPrice)
            {
                return new DecimalResponseModel
                {
                    Data = new DecimalDTO 
                    {
                        AmountLeft = sale.CashToBeSubmitted - TotalPrice
                    },
                    Message = $"Account is balance balanced but it is {sale.CashToBeSubmitted - TotalPrice} hihger"
                };
            }
            else
            {
                return new DecimalResponseModel
                {
                    Message = "Account is completely balanced."
                };
            }
            // var validClosingStock = _validClosingStockRepository.GetAllValidClosingStock().SingleOrDefault(x => x.Date.Day == Date.Day && x.Date.Month == Date.Month && x.Date.Year == Date.Year);
            // var closigstock = GetClosingSock(Date);
            // var openingStock = _openingStockRepository.GetAllOpeningStock().SingleOrDefault(x => x.Date.Day == Date.Day && x.Date.Month == Date.Month && x.Date.Year == Date.Year);
            // var sales = GetSalesByPaymentStatusAndDate(PaymentStatus.Transfer, Date);
            // decimal TotalPrice = 0;
            // decimal CalculatedTotalPrice = 0;
            // foreach (var item in sales.Data)
            // {
            //     TotalPrice += item.TotalPrice;
            // }
            // if (validClosingStock != null)
            // {
            //     TotalPrice += validClosingStock.TotalCash;
            // }
            // else
            // {
            //     var sal = GetSalesByPaymentStatusAndDate(PaymentStatus.Cash,Date);
            //     foreach (var item in sal.Data)
            //     {
            //         TotalPrice += item.TotalPrice;
            //     }
            // }
            
            // var goodReleased = GetGoodReleasedsPerDay(Date);
            // var goodReturned = GetGoodReturnedPerDay(Date);
            // for (int i = 0; i < goodReleased.Data.Count(); i++)
            // {
            //     for (int j = 0; j < goodReleased.Data[i].ProductName.Count(); j++)
            //     {
            //         var product = _productRepository.GetAllProduct().Single(x => x.Name == goodReleased.Data[i].ProductName[j]);
            //         var price = goodReleased.Data[i].Quantity[j] * product.UnitPrice;
            //         CalculatedTotalPrice += price;
            //     }
            // }
            // for (int i = 0; i < goodReturned.Data.Count(); i++)
            // {
            //     for (int j = 0; j < goodReturned.Data[i].ProductName.Count(); j++)
            //     {
            //         var product = _productRepository.GetAllProduct().Single(x => x.Name == goodReturned.Data[i].ProductName[j]);
            //         var price = goodReturned.Data[i].Quantity[j] * product.UnitPrice;
            //         CalculatedTotalPrice -= price;
            //     }
            // }
            // if (validClosingStock != null)
            // {
            //     for (int i = 0; i < openingStock.OpeningStockProducts.Count(); i++)
            //     {
            //         for (int j = 0; j < validClosingStock.ValidClosingStockProducts.Count; j++)
            //         {
            //             if (openingStock.OpeningStockProducts[i].ProductId == _productRepository.GetProductById(validClosingStock.ValidClosingStockProducts[j].ProductId).Id)
            //             {
            //                 decimal quantity = validClosingStock.ValidClosingStockProducts[j].Quantities - openingStock.OpeningStockProducts[i].Quantity;
            //                 decimal price =  _productRepository.GetProductById(validClosingStock.ValidClosingStockProducts[j].ProductId).UnitPrice * quantity;
            //                 CalculatedTotalPrice += price;
            //             }
            //         }
            //     }
            // }
            // else
            // {
            //     var closigstock1 = GetClosingSock(Date);
            //     for (int i = 0; i < openingStock.OpeningStockProducts.Count(); i++)
            //     {
            //         for (int j = 0; j < closigstock1.Data.Count; j++)
            //         {
            //             if (_productRepository.GetProductById(openingStock.OpeningStockProducts[i].ProductId).Name == closigstock.Data[j].Name)
            //             {
            //                 decimal quantity = closigstock.Data[j].Quantity - openingStock.OpeningStockProducts[i].Quantity;
            //                 decimal price = _productRepository.GetAllProduct().Single( x => x.Name == closigstock.Data[i].Name).UnitPrice * quantity;
            //                 CalculatedTotalPrice += price;
            //             }
            //         }
            //     }
            // }
            
            // // CalculatedTotalPrice += validClosingStock.PositiveDiiference;
            // // CalculatedTotalPrice -= validClosingStock.NegativeDifference;
            // if (CalculatedTotalPrice > TotalPrice)
            // {
            //     return new DecimalResponseModel
            //     {
            //         Data = new DecimalDTO
            //         {
            //             AmountLeft = Math.Round(CalculatedTotalPrice - TotalPrice,2)
            //         },
            //         Status = false,
            //         Message = $"Acount is Balance {CalculatedTotalPrice - TotalPrice}"
            //     };
            // }
            // else if (TotalPrice > CalculatedTotalPrice)
            // {
            //     return new DecimalResponseModel
            //     {
            //         Data = new DecimalDTO
            //         {
            //             AmountLeft = Math.Round(TotalPrice - CalculatedTotalPrice,2)
            //         },
            //         Status = false,
            //         Message = $"Acount is not Balance \n{TotalPrice - CalculatedTotalPrice}  left"
            //     };
            // }
            return new DecimalResponseModel
            {
                Data = new DecimalDTO
                {
                    AmountLeft = 0
                },
                Status = true,
                Message = "Acoount is completely balanced"
            };
        }
        public BaseResponse InputClosingstockForTheDay(decimal TotalCash, int SalesRepId)
        {
            Cash cash = new Cash
            {
                dateTime = DateTime.Now,
                CashToBeSubmitted = TotalCash,
                SalesRepId = SalesRepId
            };
            _cashRepository.AddCash(cash);
            
            // var closigstock = GetClosingSock(DateTime.Now);
            // int count = 0;
            // if (_validClosingStockRepository.GetAllValidClosingStock().Count() == 0)
            // {
            //     ValidClosingStock validClosingStock = new ValidClosingStock
            //     {
            //         Date = DateTime.Now,
            //         TotalCash = Math.Round(TotalCash,2),
            //     };
            //     for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //     {
            //         ValidClosingStockProduct validClosingStockProduct = new ValidClosingStockProduct
            //         {
            //             ValidClosingStockId = validClosingStock.Id,
            //             ProductId = shopItemRequestModel.ProductIds[i],
            //             Quantities = shopItemRequestModel.Quantities[i]
            //         };
            //         validClosingStock.ValidClosingStockProducts.Add(validClosingStockProduct);
            //     }
            //     foreach (var item in closigstock.Data)
            //     {
            //         for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //         {
            //             var product = _productRepository.GetProductById(shopItemRequestModel.ProductIds[i]);
            //             if (item.Name == product.Name)
            //             {
            //                 if (item.Quantity > shopItemRequestModel.Quantities[i])
            //                 {
            //                     var Quantities = item.Quantity - shopItemRequestModel.Quantities[i];
            //                     var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
            //                     decimal diff = product.UnitPrice * Quantities;
            //                     validClosingStock.NegativeDifference += diff;
            //                     shopItem.Quantity -= Quantities;
            //                     _shopItemsRepository.UpdateShopItems(shopItem);
            //                 }
            //                 else
            //                 {
            //                     var Quantities = shopItemRequestModel.Quantities[i] - item.Quantity;
            //                     var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
            //                     decimal diff = product.UnitPrice * Quantities;
            //                     validClosingStock.PositiveDiiference += diff;
            //                     shopItem.Quantity += Quantities;
            //                     _shopItemsRepository.UpdateShopItems(shopItem);
            //                 }
            //             }
            //         }
            //     }
            //     _validClosingStockRepository.AddValidClosingStock(validClosingStock);
            // }
            // else
            // {
            //     foreach (var y in _validClosingStockRepository.GetAllValidClosingStock())
            //     {
            //         count ++;
            //         if ( y.Date.Day == DateTime.Now.Day && y.Date.Month == DateTime.Now.Month && y.Date.Year == DateTime.Now.Year )
            //         {
            //             ValidClosingStock newValidClosing = _validClosingStockRepository.GetAllValidClosingStock().Single(x => x.Date.Day == DateTime.Now.Day && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year );
            //             newValidClosing.Date = DateTime.Now;
            //             newValidClosing.TotalCash = TotalCash;
            //             newValidClosing.NegativeDifference = 0;
            //             newValidClosing.PositiveDiiference = 0;
            //             for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //             {
            //                 newValidClosing.ValidClosingStockProducts[i].ValidClosingStockId = newValidClosing.Id;
            //                 newValidClosing.ValidClosingStockProducts[i].ProductId = shopItemRequestModel.ProductIds[i];
            //                 newValidClosing.ValidClosingStockProducts[i].Quantities = shopItemRequestModel.Quantities[i];
            //             }
                        
            //             foreach (var item in closigstock.Data)
            //             {
            //                 for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //                 {
            //                     var product = _productRepository.GetProductById(shopItemRequestModel.ProductIds[i]);
            //                     if (item.Name == product.Name)
            //                     {
            //                         if (item.Quantity > shopItemRequestModel.Quantities[i])
            //                         {
            //                             var Quantities = item.Quantity - shopItemRequestModel.Quantities[i];
            //                             var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
                                        
            //                             decimal diff = product.UnitPrice * Quantities;
            //                             newValidClosing.PositiveDiiference  += diff;
            //                             shopItem.Quantity += Quantities;
            //                             _shopItemsRepository.UpdateShopItems(shopItem);
            //                         }
            //                         else
            //                         {
            //                             var Quantities = shopItemRequestModel.Quantities[i] - item.Quantity;
            //                             var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
            //                             decimal diff = product.UnitPrice * Quantities;
            //                             newValidClosing.NegativeDifference += diff;
            //                             shopItem.Quantity -= Quantities;
            //                             _shopItemsRepository.UpdateShopItems(shopItem);
            //                         }
            //                     }
            //                 }
            //             }
            //             _validClosingStockRepository.DeleteValidClosingStock(newValidClosing);
            //         }
            //         else if(count == _validClosingStockRepository.GetAllValidClosingStock().Count())
            //         {
            //             ValidClosingStock validClosingStock = new ValidClosingStock
            //             {
            //                 Date = DateTime.Now,
            //                 TotalCash = TotalCash
            //             };
            //             for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //             {
            //                 ValidClosingStockProduct validClosingStockProduct = new ValidClosingStockProduct
            //                 {
            //                     ValidClosingStockId = validClosingStock.Id,
            //                     ProductId = shopItemRequestModel.ProductIds[i],
            //                     Quantities = shopItemRequestModel.Quantities[i]
            //                 };
            //                 validClosingStock.ValidClosingStockProducts.Add(validClosingStockProduct);
            //             }
            //             foreach (var item in closigstock.Data)
            //             {
            //                 for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
            //                 {
            //                     var product = _productRepository.GetProductById(shopItemRequestModel.ProductIds[i]);
            //                     if (item.Name == product.Name)
            //                     {
            //                         if (item.Quantity > shopItemRequestModel.Quantities[i])
            //                         {
            //                             var Quantities = item.Quantity - shopItemRequestModel.Quantities[i];
            //                             var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
            //                             validClosingStock.NegativeDifference = product.UnitPrice * Quantities;
            //                             shopItem.Quantity -= Quantities;
            //                             _shopItemsRepository.UpdateShopItems(shopItem);
            //                         }
            //                         else
            //                         {
            //                             var Quantities = shopItemRequestModel.Quantities[i] - item.Quantity;
            //                             var shopItem = _shopItemsRepository.GetShopItemsByName(product.Name);
            //                             validClosingStock.PositiveDiiference = product.UnitPrice * Quantities;
            //                             shopItem.Quantity += Quantities;
            //                             _shopItemsRepository.UpdateShopItems(shopItem);
            //                         }
            //                     }
            //                 }
            //             }
            //             _validClosingStockRepository.AddValidClosingStock(validClosingStock);
            //         }
            //     }

            // }   
            return new BaseResponse
            {
                Message = " ",
                Status = true
            };
        }
        // public BaseResponse InputClosingstockForTheDay(GoodReleasedRequestModel shopItemRequestModel)
        // {
        //     List<ShopItemDTO> shopItemDTOs = new List<ShopItemDTO>();
        //     var shopItems = GetClosingSock(DateTime.Now);
        //     for (int i = 0; i < shopItemRequestModel.ProductIds.Count(); i++)
        //     {
        //         for (int j = 0; j < shopItems.Data.Count; j++)
        //         {
        //             var product = _productRepository.GetProductById(shopItemRequestModel.ProductIds[i]);
        //             if (shopItems.Data[i].Name == product.Name)
        //             {
        //                 if (shopItems.Data[i].Quantity > shopItemRequestModel.Quantities[i])
        //                 {
        //                     ShopItemDTO shopItemDTO = new ShopItemDTO
        //                     {
        //                         Name = shopItems.Data[i].Name,
        //                         Quantity = shopItemDTOs[i].Quantity - shopItemRequestModel.Quantities[i]
        //                     };
        //                     shopItemDTOs.Add(shopItemDTO);
        //                 }
        //             }
        //         }
        //     }
        //     decimal Total = 0;
        //     foreach (var item in GetSalesInDay(DateTime.Now).Data)
        //     {
        //         Total += item.TotalPrice;
        //     }
        // }
        public SalesResponseModel GetSalesInDay(DateTime Date)
        {
            var sales = _salesRepository.GetAllSales().Where(x => x.TimeOfTransaction.Day <= Date.Day && x.TimeOfTransaction.Day >= x.TimeOfTransaction.Day - Date.Day).ToList();
            if (sales == null)
            {
                return new SalesResponseModel
                {
                    Message = " ",
                    Status = false
                };
            }
            List<SalesDTO> salesDTOs = new List<SalesDTO>();
            foreach (var item in sales)
            {
                List<string> ProductName = new List<string>();
                List<decimal> ProductQuantity = new List<decimal>();
                for (int i = 0; i < item.SalesProducts.Count(); i++)
                {
                    var product = _productRepository.GetProductById(item.SalesProducts[i].ProductId);
                    ProductName.Add(product.Name);
                    var sale = _salesRepository.GetSalesById(item.SalesProducts[i].SalesId);
                    ProductQuantity.Add(sale.SalesProducts[i].ProductQuantities);
                }
                SalesDTO salesDTO = new SalesDTO
                {
                    Id = item.Id,
                    TimeOfTransaction = item.TimeOfTransaction,
                    TotalPrice = item.TotalPrice,
                    SalesRep = _salesRepRepository.GetSalesRepById(item.SalesRepId).FirstName,
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    PaymentStatus = item.PaymentStatus.ToString()
                };
                salesDTOs.Add(salesDTO);
            }
            return new SalesResponseModel
            {
                Data = salesDTOs,
                Message = "",
                Status = true
            };
        }
    }
}