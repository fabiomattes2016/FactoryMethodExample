using FactoryMethodExample.Models;
using FactoryMethodExample.Repositories;
using FactoryMethodExample.Responses.JsonPlaceHolder;
using static System.Console;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Login();
            //var data = FindPostById();

            WriteLine(data.ToString());
            ReadLine();
        }

        public static TokenResponse Login()
        {
            MinhaApiRepository minhaApiRepository = new MinhaApiRepository();

            WriteLine("Acessando API, aguarde um momento...");

            var email = "fabiomattes2007@gmail.com";
            var password = "Senh@123";

            var loginTask = minhaApiRepository.LoginAsync(email, password);

            TokenResponse tokens = loginTask.Result;
            return tokens;
        }

        public static PostResponse FindPostById()
        {
            JsonPlaceHolderRepository jsonPlaceHolderRepository = new JsonPlaceHolderRepository();

            WriteLine("Acessando API, aguarde um momento...");

            int id = 1;

            var postTask = jsonPlaceHolderRepository.FindById(id);

            PostResponse post = postTask.Result;
            return post;
        }
    }
}
