create trigger AtualizarPrecoPedido
on Itens_Pedidos
after insert
as
begin

    declare @idPedInserted int
    declare @qntdPedInserted int
    declare @precoPedInserted money

    set @idPedInserted = (select idPedido from inserted)
    set @precoPedInserted = (select precoItensPedido from inserted)
    set @qntdPedInserted = (select quantidadeItensPedido from inserted)

    update Pedidos 
    set preco = preco + (@precoPedInserted * @qntdPedInserted) 
    where idPedido = @idPedInserted

end