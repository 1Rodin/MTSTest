SELECT 
	p.ClientName,
	MONTH(p."Date") AS "Month",
	(
		SELECT SUM(po.Amount)
		FROM [Post] po
		WHERE 
			po.ClientName = p.ClientName 
			AND YEAR(po."Date") = YEAR(p."Date") 
			AND MONTH(po."Date") <= MONTH(p."Date") 
	) AS "SumAmount"
FROM [Post] p
WHERE YEAR(p."Date") = 2017
GROUP BY p.ClientName, YEAR(p."Date"), MONTH(p."Date")
ORDER BY ClientName desc, MONTH(p."Date")



[Post] - название таблицы, писать create и insert сюда не стал
