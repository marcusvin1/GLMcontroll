create trigger retiraDoEstoque
on Itens_Pedidos
after insert
as
begin

	declare @getIdEstoqueInserted int
	declare @getQtdInserted int

	set @getIdEstoqueInserted = (select idEstoque from inserted)
	set @getQtdInserted = (select quantidadeItensPedido from inserted)

	update Estoque 
	set qtdEstoque = (qtdEstoque - @getQtdInserted)
	where idEstoque = @getIdEstoqueInserted

end