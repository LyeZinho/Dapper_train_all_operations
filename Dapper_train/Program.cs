using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections;
using System;
using Dapper_train;

//Armazena uma 
string connStr = "server=localhost;database=users;userid=root;password=123456789;";

using (MySqlConnection conn = new MySqlConnection(connStr))
{
    //Query sql
    string sql = "Select * from user;";
    //Realiza a query e converte para o tipo User
    //Converte a query para uma lista e armazena em uma variavel do tipo dinamica chamada query
    dynamic query = conn.Query<User>(sql).ToList();
    //Escreve os dados do parametro Username para o indice [0] da variavel dynamica query
    foreach (var item in query)
    {
        Console.WriteLine("Query :"+item.Username + " " + item.Email);
    }
    Console.WriteLine("------------------------------------");
}

using (MySqlConnection conn = new MySqlConnection(connStr))
{   
    //Query sql
    string sql = "select (username) from user where username = 'pedro';";

    //Query scalar ou seja so pode retornar um valor de cada vez
    dynamic query = conn.ExecuteScalar<string>(sql);

    //Escreve os dados da variavel query do tipo dinamico
    Console.WriteLine("Query scalar: "+query);
    Console.WriteLine("------------------------------------");    
}

using (MySqlConnection conn = new MySqlConnection(connStr))
{
    //Query sql
    string sql = "select * from user where username = 'pedro';";

    //Busca o primeiro registro que retornar da pesquisa
    //Usar apenas quando espera que será retornado somente um registro
    dynamic query = conn.QuerySingle<User>(sql);

    //Escreve os dados da variavel query do tipo dinamico
    Console.WriteLine("Query single: "+query.Username + " " + query.Email);
    Console.WriteLine("------------------------------------");
}


//using (MySqlConnection conn = new MySqlConnection(connStr))
//{
//Operações de não pesquisa  (Insert)
//sql comando
//    string sql = "insert into user (username, email) values (@username, @email);";

//    //Parametros da query
//    var param = new
//    {
//        username = "joão",
//        email = "joão@demo.com"

//    };

//    //Executa a query e retorna o numero de linhas afetadas
//    int query = conn.Execute(sql, param);

//    //Escreve o numero de linhas afetadas
//    Console.WriteLine("Query insert: " + query);
//    Console.WriteLine("------------------------------------");
//}



//using (MySqlConnection conn = new MySqlConnection(connStr))
//{
//    //Operações de não pesquisa (Update)
//    //sql comando
//    string sql = "update user set email = @email where username = @username;";

//    //Parametros da query
//    var param = new
//    {
//        username = "joão",
//        email = "joaobusiness@demo.com"
//    };

//    //Executa a query e retorna o numero de linhas afetadas
//    int query = conn.Execute(sql, param);

//    //Escreve o numero de linhas afetadas
//    Console.WriteLine("Query update: " + query);
//    Console.WriteLine("------------------------------------");
//}

//using (MySqlConnection conn = new MySqlConnection(connStr))
//{
//    //operações de não pesquisa (delete)
//    //sql comando
//    string sql = "delete from user where username = @username;";

//    //parametros da query
//    var param = new
//    {
//        username = "joão"
//    };

//    //executa a query e retorna o numero de linhas afetadas
//    int query = conn.Execute(sql, param);

//    //escreve o numero de linhas afetadas
//    Console.WriteLine("query delete: " + query);
//    Console.WriteLine("------------------------------------");
//}



//https://www.tutorialsteacher.com/csharp/csharp-hashtable
//StortedList<TKey, TValue>
//
SortedList<string, string> param = new SortedList<string, string>();
param.Add("one", "joão");
param.Add("two", "pedro");
param.Add("three", "maria");
param.Add("four", "jose");

Console.WriteLine("Sorted list: "+param["one"]);
Console.WriteLine("------------------------------------");




using (MySqlConnection conn = new MySqlConnection(connStr))
{
    //Cria um novo dicionario
    var dicionario = new Dictionary<string, object>
    {
        //adciona os valores "@username" e "joão"
        //"@username" <- chave do parametro
        //"joão" <- valor a ser inserido
        {"@username", "pedro" }
    };

    //Cria um novo objeto do tipo DynamicParameters 
    //transforma a variavel dicionario em um objeto do tipo DynamicParameters
    //armazena o resultado em parametrosdinam
    var parametrosdinam = new DynamicParameters(dicionario);

    string sql = "select * from user where username = @username";

    dynamic query = conn.Query<User>(sql, parametrosdinam);

    Console.WriteLine("Param dinam: " + query[0].Username + " " + query[0].Email);
    Console.WriteLine("------------------------------------");
}


using (MySqlConnection conn = new MySqlConnection(connStr))
{
    //Cria um novo objeto do tipo DynamicParameters 
    //que recebe como parametros um tipo anonimo: new { username = "pedro"}
    var parametrosdinamanon = new DynamicParameters(new { username = "pedro" });

    string sql = "select * from user where username = @username";

    dynamic query = conn.Query<User>(sql, parametrosdinamanon);
    Console.WriteLine("Anonimo Param dinam: " + query[0].Username + " " + query[0].Email);
    Console.WriteLine("------------------------------------");
}



