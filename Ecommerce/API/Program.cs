using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos fakes
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Camiseta Básica", Quantidade = 50, Preco = 29.99 },
    new Produto { Nome = "Calça Jeans", Quantidade = 30, Preco = 99.90 },
    new Produto { Nome = "Tênis Esportivo", Quantidade = 20, Preco = 149.50 },
    new Produto { Nome = "Mochila Escolar", Quantidade = 15, Preco = 79.99 },
    new Produto { Nome = "Relógio Digital", Quantidade = 10, Preco = 199.90 },
    new Produto { Nome = "Óculos de Sol", Quantidade = 25, Preco = 59.90 },
    new Produto { Nome = "Boné Aba Curva", Quantidade = 40, Preco = 39.99 },
    new Produto { Nome = "Jaqueta de Couro", Quantidade = 5, Preco = 299.99 },
    new Produto { Nome = "Meias Esportivas", Quantidade = 100, Preco = 9.90 },
    new Produto { Nome = "Cinto de Couro", Quantidade = 35, Preco = 49.90 }
};

app.MapGet("/", () => "API de Produtos");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    //Validar a lista de produtos para saber 
    //se existe algo dentro
    if (produtos.Any())
    {
        return Results.Ok(produtos);
    }
    return Results.NotFound("Lista vazia!");
});

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    //Expressão lambda
    Produto? resultado =
        produtos.FirstOrDefault(x => x.Nome == nome);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado!");        
    }
    return Results.Ok(resultado);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar",
    ([FromBody] Produto produto) =>
{
    //Não permitir o cadastro de um produto
    //com o mesmo nome
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado!");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});

// delete /api/produto/delete/id
app.MapDelete("/api/produto/delete/{id}", ([FromRoute] string id) =>
{
    Produto? resultado = produtos.FirstOrDefault(p => p.Id == id);
    if (resultado is null)
    {
        return Results.NotFound("produto não encontrado");
    }
    produtos.Remove(resultado);
    return Results.NoContent();
});

app.MapDelete("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    Produto? resultado = produtos.FirstOrDefault(p => p.Id == id);
    if (resultado is null)
    {
        return Results.NotFound("produto não encontrado");
    }
    resultado.Nome = produtoAlterado.Nome;
    resultado.Quantidade = produtoAlterado.Quantidade;
    resultado.Preco = produtoAlterado.Preco;
    return Results.NoContent();
});
//Implementar a remoção e atualização do produto
app.Run();