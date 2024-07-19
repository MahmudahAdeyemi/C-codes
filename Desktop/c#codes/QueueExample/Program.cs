using QueueExample;

var Queue = new OnQueue<Resturant>();
Resturant resturant = new Resturant{Name ="FoodCo"};
Queue.Enqueue(resturant);