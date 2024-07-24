select * from PERSONAS p
inner join PARENTESCOS pa on p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre
where pa.Parentesco = 'CNYG'

select * from PERSONAS p
inner join PARENTESCOS pa on p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre
inner join PARAMETROS pr on pa.Parentesco = pr.CODCorto
where pr.DESCRIPCION = 'Cónyuge'

select * from PERSONAS p
inner join PARENTESCOS pa on p.NDoc = pa.NDocHijo and p.TDoc = pa.TDocHijo
inner join PARAMETROS pr on pa.Parentesco = pr.CODCorto
where pr.DESCRIPCION = 'Cónyuge'

select * from PERSONAS p
inner join PARENTESCOS pa on p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre
inner join PARAMETROS pr on pa.Parentesco = pr.CODCorto
where pr.DESCRIPCION = 'Hijo'

select * from PERSONAS p
left join PARENTESCOS pa on p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre
where pa.NDocHijo is null and pa.TDocPadre is null


select * from PARENTESCOS parh
inner join PARENTESCOS parc on parh.NDocPadre = parc.NDocPadre
inner join PERSONAS per on per.NDoc = parh.NDocHijo and per.TDoc = parh.TDocHijo
where parh.Parentesco = 'HIJO' and parc.Parentesco = 'CNYG'



select * from PERSONAS p
inner join PARENTESCOS pa on p.NDoc = pa.NDocHijo and p.TDoc = pa.TDocHijo
where pa.Parentesco = 'HIJO' and p.Cargo is not null and  DATEDIFF(YEAR,p.FechaNacimiento, GETDATE()) < 18

select Tipo_Contacto,count(NDoc) as 'Numero de personas' from CONTACTOS 
group by Tipo_Contacto 


select Tipo_Contacto, Estado ,count(NDoc) as 'Numero de personas'  from CONTACTOS 
group by Tipo_Contacto, Estado 






select * from PARENTESCOS pa
inner join PERSONAS p on pa.NDocPadre = p.NDoc and pa.TDocPadre = p.TDoc
inner join 

select * from PERSONAS p
full join PARENTESCOS pa on p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre and p.NDoc =pa.

select NDocPadre ,NDocHijo, Parentesco from PARENTESCOS
order by NDocPadre ,NDocHijo, Parentesco













select * from PERSONAS p
where not exists (select * from PARENTESCOS pa where  p.NDoc = pa.NDocPadre and p.TDoc = pa.TDocPadre)


select * from ORDERS o
inner join PERSONAS p on o.CUSTOMER_ID = p.NDoc