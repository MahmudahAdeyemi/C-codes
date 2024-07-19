using Transaction.DTO;using Transaction.Entities;using Transaction.Implementation.Repositories;using Transaction.Interfaces.Repositories;using Transaction.Interfaces.Services;using Transaction.RequestModel;using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class StoreKeepingService : IStoreKeepingService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStoreItemsRepository _storeItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGoodRealesdRepository _goodRealesedRepository;
        private readonly IShopItemsRepository _shopItemsRepository;
        private readonly IGoodReturnedRepository _goodReturnedRepository;
        private readonly IOpeningStockRepository _openingStockRepository;
        private readonly ISalesRepository _salesRepository;

        public StoreKeepingService(IPurchaseRepository purchaseRepository, IStoreItemsRepository storeItemsRepository, IProductRepository productRepository, IGoodRealesdRepository goodRealesedRepository, IShopItemsRepository shopItemsRepository, IGoodReturnedRepository goodReturnedRepository, IOpeningStockRepository openingStockRepository, ISalesRepository salesRepository)
        {
            _purchaseRepository = purchaseRepository;
            _storeItemsRepository = storeItemsRepository;
            _productRepository = productRepository;
            _goodRealesedRepository = goodRealesedRepository;
            _shopItemsRepository = shopItemsRepository;
            _goodReturnedRepository = goodReturnedRepository;
            _openingStockRepository = openingStockRepository;
            _salesRepository = salesRepository;
        }

        public BaseResponse AddGoodsToStore(PurchaceRequestModel purchaceRequestModel)
        {
            decimal PotalPrice = 0;
            var generated = Guid.NewGuid();
            Purchace purchace = new Purchace
            {
                Date = DateTime.Now,
                PurchaceReferenceNumber = generated.ToString().Remove(2, 5)
            };

            List<string> storeItemsNames;
            for (int i = 0; i < purchaceRequestModel.ProductIds.Count(); i++)
            {
                var productPurchace = new ProductPurchace
                {
                    Quantity = Math.Round(purchaceRequestModel.Quantities[i],2),
                    PurchacedPrice = purchaceRequestModel.PurchacedPrice[i],
                    ProductId = purchaceRequestModel.ProductIds[i],
                    PurchaceId = purchace.Id
                };
                decimal potalPrice = productPurchace.Quantity * productPurchace.PurchacedPrice;
                PotalPrice += potalPrice;
                purchace.ProductPurchaces.Add(productPurchace);
            }
            purchace.TotalPrice = Math.Round(PotalPrice,2);
            _purchaseRepository.AddPurchace(purchace);

            for (int i = 0; i < purchaceRequestModel.ProductIds.Count(); i++)
            {
                var product = _productRepository.GetProductById(purchaceRequestModel.ProductIds[i]);
                storeItemsNames = _storeItemsRepository.GetAllStoreItems().Select(d => d.Name).ToList();
                var storeItem = new StoreItems
                {
                    Name = product.Name,
                    Quantity = Math.Round(purchaceRequestModel.Quantities[i],2)
                };
                if (!(storeItemsNames.Contains(storeItem.Name)))
                {
                    _storeItemsRepository.AddStoreItems(storeItem);
                }
                else
                {
                    var storeItem1 = _storeItemsRepository.GetStoreItemsByName(storeItem.Name);
                    storeItem1.Quantity +=Math.Round( storeItem.Quantity,2);
                    var c = _storeItemsRepository.UpdateStoreItems(storeItem1);
                }

            }

            //_purchaseRepository.UpdatePurchace(purchace);
            return new BaseResponse
            {
                Message = "Purchase sucessfully added",
                Status = true
            };

        }
        
        public BaseResponse ReturnGoodsToStore(GoodReleasedRequestModel goodReleasedRequestModel)
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
            List<string> shopItemNames = new List<string>();
            GoodsReturned goodsReturned = new GoodsReturned
            {
                DateReleased = DateTime.Now
            };
            for (int i = 0; i < goodReleasedRequestModel.ProductIds.Count(); i++)
            {
                var goodsReturnedProduct = new GoodsReturnedProduct
                {
                    ProductId = goodReleasedRequestModel.ProductIds[i],
                    Quantity =Math.Round( goodReleasedRequestModel.Quantities[i],2)
                };
                goodsReturned.GoodsReturnedProducts.Add(goodsReturnedProduct);
            }
            _goodReturnedRepository.AddGoodsReturned(goodsReturned);
            for (int i = 0; i < goodReleasedRequestModel.ProductIds.Count(); i++)
            {
                var product = _productRepository.GetProductById(goodReleasedRequestModel.ProductIds[i]);
                shopItemNames = _shopItemsRepository.GetAllShopItems().Select(x => x.Name ).ToList();
                ShopItems shopItem = new ShopItems
                {
                    Name = product.Name,
                    Quantity =Math.Round( goodReleasedRequestModel.Quantities[i],2)
                };
                if (!(shopItemNames.Contains(shopItem.Name)))
                {
                    _shopItemsRepository.AddShopItems(shopItem);
                }
                else
                {
                    var shopItems = _shopItemsRepository.GetShopItemsByName(shopItem.Name);
                    shopItems.Quantity = shopItems.Quantity - goodReleasedRequestModel.Quantities[i];
                }
            }
            for (int i = 0; i < goodReleasedRequestModel.Quantities.Count; i++)
            {
                var product = _productRepository.GetProductById(goodReleasedRequestModel.ProductIds[i]);
                StoreItems storeItems = _storeItemsRepository.GetStoreItemsByName(product.Name);
                storeItems.Quantity += goodReleasedRequestModel.Quantities[i];
                _storeItemsRepository.UpdateStoreItems(storeItems);
            }
            return new BaseResponse
            {
                Message = "Sucessfully done",
                Status = true
            };
        }
        public BaseResponse ReleaseGoodsToShop(GoodReleasedRequestModel goodReleasedRequestModel)
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
            List<string>shopItemNames = new List<string>();
            GoodReleased goodReleased = new GoodReleased
            {
                DateReleased = DateTime.Now,

            };
            for (int i = 0; i < goodReleasedRequestModel.ProductIds.Count(); i++)
            {
                var goodReleasedProduct = new GoodReleasedProduct
                {
                    ProductId = goodReleasedRequestModel.ProductIds[i],
                    Quantity = goodReleasedRequestModel.Quantities[i]
                };
                goodReleased.GoodReleasedProducts.Add(goodReleasedProduct);
            }
            _goodRealesedRepository.AddGoodReleased(goodReleased);
            for (int i = 0; i < goodReleasedRequestModel.ProductIds.Count(); i++)
            {
                var product = _productRepository.GetProductById(goodReleasedRequestModel.ProductIds[i]);
                shopItemNames = _shopItemsRepository.GetAllShopItems().Select(x => x.Name).ToList();
                ShopItems shopItems = new ShopItems
                {
                    Name = product.Name,
                    Quantity = goodReleasedRequestModel.Quantities[i]
                };
                if (!(shopItemNames.Contains(shopItems.Name)))
                {
                    _shopItemsRepository.AddShopItems(shopItems);
                }
                else
                {
                    var shopItem = _shopItemsRepository.GetShopItemsByName(shopItems.Name);
                    shopItem.Quantity += goodReleasedRequestModel.Quantities[i];
                }
            }
            for (int i = 0; i < goodReleasedRequestModel.Quantities.Count(); i++)
            {
                var product = _productRepository.GetProductById(goodReleasedRequestModel.ProductIds[i]);
                StoreItems storeItems = _storeItemsRepository.GetStoreItemsByName(product.Name);
                storeItems.Quantity =storeItems.Quantity - goodReleasedRequestModel.Quantities[i];
                _storeItemsRepository.UpdateStoreItems(storeItems);
            }
            return new BaseResponse
            {
                Message = "Sucessfully done",
                Status = true
            };
            
        }

        // // public GoodReleaseResponseModel GetAllGoodsReleased()
        // // {

        // // }

        public StoreItemsResponseModel GetAllStoreItems()
        {

            var Product = _storeItemsRepository.GetAllStoreItems();
            if (Product == null)
            {
                return new StoreItemsResponseModel
                {
                    Status = false,
                    Message = "No store item retrieved"

                };
            }
            var ProductReturned = Product.Select(sr => new StoreItemDTO
            {
                Id = sr.Id,
                Name = sr.Name,
                Quantity = sr.Quantity
            }).ToList();

            return new StoreItemsResponseModel
            {
                Datas = ProductReturned,
                Message = "",
                Status = true
            };

        }
        // public GoodReleaseResponseModel GetGoodReleasedByMonth(int month)
        // {
            
        // }

        public PurchacesResponseModel GetPurchacesByMonth(Month month)
        {
            var goodrealesed  = _purchaseRepository.GetAllPurchace().Where(x => x.Date.Month == (int)month).ToList();
            if (goodrealesed == null)
            {
                return new PurchacesResponseModel
                {
                    Status = false,
                    Message = "No purchase found"
                };
                
            }
            
            var goodreturned = goodrealesed.Select(sr => new PurchaceDTO
            {
                Id = sr.Id,
                PurchaceReferenceNumber = sr.PurchaceReferenceNumber,
                TotalPrice = sr.TotalPrice,
                Date = sr.Date
            }).ToList();
            return new PurchacesResponseModel
            {
                Data = goodreturned,
                Status = true
            };
        }

        

        public BaseResponse UpdatePurchasedItems(int id, UpdatePurchaceItemRequestModel updatePurchaceItem)
        {
            List<string> storeItemsNames;
            decimal TotalPrice = 0;
            var purchace = _purchaseRepository.GetPurchaceById(id);
            if (purchace == null)
            {
                return new BaseResponse
                {
                    Message = "Purchase not found",
                    Status = false
                };

            }
            for (int i = 0; i < updatePurchaceItem.ProductIds.Count(); i++)
            {
                var product = _productRepository.GetProductById(updatePurchaceItem.ProductIds[i]);
                storeItemsNames = _storeItemsRepository.GetAllStoreItems().Select(d => d.Name).ToList();
                var storeItem = new StoreItemDTO
                {
                    Name = product.Name,
                    Quantity = updatePurchaceItem.Quantities[i]
                };
                var storeItem1 = _storeItemsRepository.GetAllStoreItems().Single(x => x.Name == storeItem.Name);
                foreach (var item in storeItemsNames)
                {
                    if (item == storeItem.Name)
                    {
                        storeItem1.Quantity = storeItem1.Quantity + updatePurchaceItem.Quantities[i];
                        storeItem1.Quantity = storeItem1.Quantity - purchace.ProductPurchaces[i].Quantity;
                        _storeItemsRepository.UpdateStoreItems(storeItem1);
                    }
                }
                _storeItemsRepository.UpdateStoreItems(storeItem1);
            }

            for (int i = 0; i < updatePurchaceItem.PurchacedPrice.Count(); i++)
            {
                var productPurchace = new ProductPurchace
                {
                    Quantity = updatePurchaceItem.Quantities[i],
                    PurchacedPrice = updatePurchaceItem.PurchacedPrice[i],
                    ProductId = updatePurchaceItem.ProductIds[i],
                    PurchaceId = purchace.Id,
                };
                decimal potalPrice = productPurchace.Quantity * productPurchace.PurchacedPrice;
                TotalPrice += potalPrice;
                purchace.ProductPurchaces[i].ProductId = productPurchace.ProductId;
                purchace.ProductPurchaces[i].Quantity = productPurchace.Quantity;
                purchace.ProductPurchaces[i].PurchacedPrice = productPurchace.PurchacedPrice;
            }
            purchace.TotalPrice = TotalPrice;
            _purchaseRepository.UpdatePurchace(purchace);
            // for (int i = 0; i < updatePurchaceItem.ProductIds.Count(); i++)
            // {
            //     var product = _productRepository.GetProductById(updatePurchaceItem.ProductIds[i]);
            //     storeItemsNames = _storeItemsRepository.GetAllStoreItems().Select(d => d.Name).ToList();
            //     var storeItem = new StoreItemDTO
            //     {
            //         Name = product.Name,
            //         Quantity = updatePurchaceItem.Quantities[i]
            //     };
            //     var storeItem1 = _storeItemsRepository.GetAllStoreItems().Single(x => x.Name == storeItem.Name);
            //     foreach (var item in storeItemsNames)
            //     {
            //         if (item == storeItem.Name)
            //         {
            //             storeItem1.Quantity = storeItem1.Quantity + updatePurchaceItem.Quantities[i];
            //             _storeItemsRepository.UpdateStoreItems(storeItem1);
            //         }
            //     }
            //     _storeItemsRepository.UpdateStoreItems(storeItem1);

            // }
            return new BaseResponse
            {
                Message = "Sucessfully Updated",
                Status = true
            };

        }
        public BaseResponse UpdateReleasdItems(int id, UpdateGoodReleasedItemsRequestModel updateGoodReleasedItemsRequestModel)
        {
            List<string> storeItemsNames;
            decimal TotalPrice = 0;
            var purchace = _goodRealesedRepository.GetGoodReleasedById(id);
            if (purchace == null)
            {
                return new BaseResponse
                {
                    Message = "Purchase not found",
                    Status = false
                };

            }
            for (int i = 0; i < updateGoodReleasedItemsRequestModel.ProductId.Count(); i++)
            {
                var product = _productRepository.GetProductById(updateGoodReleasedItemsRequestModel.ProductId[i]);
                storeItemsNames = _storeItemsRepository.GetAllStoreItems().Select(d => d.Name).ToList();
                var storeItem = new StoreItemDTO
                {
                    Name = product.Name,
                    Quantity = updateGoodReleasedItemsRequestModel.Quantity[i]
                };
                var storeItem1 = _storeItemsRepository.GetAllStoreItems().Single(x => x.Name == storeItem.Name);
                foreach (var item in storeItemsNames)
                {
                    if (item == storeItem.Name)
                    {
                        storeItem1.Quantity = storeItem1.Quantity - updateGoodReleasedItemsRequestModel.Quantity[i];
                        storeItem1.Quantity = storeItem1.Quantity + purchace.GoodReleasedProducts[i].Quantity;
                        _storeItemsRepository.UpdateStoreItems(storeItem1);
                    }
                }
                _storeItemsRepository.UpdateStoreItems(storeItem1);
            }
            for (int i = 0; i < updateGoodReleasedItemsRequestModel.ProductId.Count(); i++)
            {
                var product = _productRepository.GetProductById(updateGoodReleasedItemsRequestModel.ProductId[i]);
                storeItemsNames = _shopItemsRepository.GetAllShopItems().Select(d => d.Name).ToList();
                var storeItem = new ShopItemDTO
                {
                    Name = product.Name,
                    Quantity = updateGoodReleasedItemsRequestModel.Quantity[i]
                };
                var shopItem1 = _shopItemsRepository.GetAllShopItems().Single(x => x.Name == storeItem.Name);
                foreach (var item in storeItemsNames)
                {
                    if (item == storeItem.Name)
                    {
                        shopItem1.Quantity = shopItem1.Quantity + updateGoodReleasedItemsRequestModel.Quantity[i];
                        shopItem1.Quantity = shopItem1.Quantity - purchace.GoodReleasedProducts[i].Quantity;
                        _shopItemsRepository.UpdateShopItems(shopItem1);
                    }
                }
                _shopItemsRepository.UpdateShopItems(shopItem1);
            }
            for (int i = 0; i < updateGoodReleasedItemsRequestModel.ProductId.Count(); i++)
            {
                var productPurchace = new ProductPurchace
                {
                    Quantity = updateGoodReleasedItemsRequestModel.Quantity[i],
                    ProductId = updateGoodReleasedItemsRequestModel.ProductId[i],
                    PurchaceId = purchace.Id
                };
                decimal potalPrice = productPurchace.Quantity * productPurchace.PurchacedPrice;
                TotalPrice += potalPrice;
                purchace.GoodReleasedProducts[i].ProductId = productPurchace.ProductId;
                purchace.GoodReleasedProducts[i].Quantity = productPurchace.Quantity;
            }
            _goodRealesedRepository.UpdateGoodReleased(purchace);
            // for (int i = 0; i < updatePurchaceItem.ProductIds.Count(); i++)
            // {
            //     var product = _productRepository.GetProductById(updatePurchaceItem.ProductIds[i]);
            //     storeItemsNames = _storeItemsRepository.GetAllStoreItems().Select(d => d.Name).ToList();
            //     var storeItem = new StoreItemDTO
            //     {
            //         Name = product.Name,
            //         Quantity = updatePurchaceItem.Quantities[i]
            //     };
            //     var shopItem1 = _storeItemsRepository.GetAllStoreItems().Single(x => x.Name == storeItem.Name);
            //     foreach (var item in storeItemsNames)
            //     {
            //         if (item == storeItem.Name)
            //         {
            //             storeItem1.Quantity = storeItem1.Quantity + updatePurchaceItem.Quantities[i];
            //             _storeItemsRepository.UpdateStoreItems(storeItem1);
            //         }
            //     }
            //     _storeItemsRepository.UpdateStoreItems(storeItem1);

            // }
            return new BaseResponse
            {
                Message = "Sucessfully Updated",
                Status = true
            };

        }

        
    }
}
