// See https://aka.ms/new-console-template for more information

List <double> fibonacciSeries = new List<double>();
fibonacciSeries.Add(0);
fibonacciSeries.Add(1);

//Fibonacci series with recursion:
double fibonacci(int n){
    if(n==0){
        return fibonacciSeries[n];
    }
    if(n==1){
        return fibonacciSeries[n];
    }
    fibonacciSeries.Add(fibonacciSeries[n - 1] + fibonacciSeries[n - 2]);
    return fibonacciSeries[n];
}

for(int i = 0; i < 50; i++){
    Console.WriteLine(i + " -> " +fibonacci(i));
}