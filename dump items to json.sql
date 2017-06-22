select ItemChainName,
	   ItemChainType,
	   (select ItemName, IconPath
		  from Item
			 inner join ItemChainItem
				on Item.ItemID = ItemChainItem.ItemID
		  where ItemChainItem.ItemChainID = ItemChain.ItemChainID
		  for json path
	   ) as ItemChain,
	   DefaultEnabled,
	   Loopable,
	   Countable,
	   MaxCount
    from ItemChain
    order by ItemChain.SortOrder
    for json path
