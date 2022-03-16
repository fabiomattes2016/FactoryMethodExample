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
            WriteLine("Acessando API, aguarde um momento...");
            WriteLine("----------------------------------------");

            //var data = Login();
            //var data = Logout();
            var data = FindPostById();

            WriteLine(data.ToString());
            WriteLine("----------------------------------------");
            ReadLine();
        }

        public static TokenResponse Login()
        {
            WriteLine("Efetuando o login, aguarde um momento...");
            WriteLine("----------------------------------------");

            MinhaApiRepository minhaApiRepository = new MinhaApiRepository();

            var email = "fabiomattes2007@gmail.com";
            var password = "Senh@123";

            var loginTask = minhaApiRepository.LoginAsync(email, password);

            TokenResponse tokens = loginTask.Result;
            return tokens;
        }

        public static string Logout()
        {
            var tokens = Login();
            var accessToken = tokens.access_token;
            var refreshToken = tokens.refresh_token;

            MinhaApiRepository minhaApiRepository = new MinhaApiRepository();

            WriteLine("Deslogando, aguarde um momento...");
            WriteLine("----------------------------------------");

            var logoutTask = minhaApiRepository.LogoutAsync(accessToken);

            string resposta = logoutTask.Result;

            return resposta;
        }

        public static PostResponse FindPostById()
        {
            JsonPlaceHolderRepository jsonPlaceHolderRepository = new JsonPlaceHolderRepository();

            int id = 1;

            var postTask = jsonPlaceHolderRepository.FindById(id);

            PostResponse post = postTask.Result;
            return post;
        }
    }
}
