alter PROCEDURE allmovieshow
AS
BEGIN
	select * from movieentities order by moviename
END
GO

CREATE PROCEDURE getmbyid
@mid int
AS
BEGIN
	select * from movieentities where movieid=@mid
END
GO


alter proc search_name
@name varchar(20)
as
begin
   select * from movieentities where moviename LIKE '%'+@name+'%' order by movieyear desc;
end



--do t2.value==null --> then t2=t1;
alter proc search_year
@year1 int, @year2 int 
as
begin
if(@year1>@year2)
begin
   select * from movieentities where movieyear < = @year1 and movieyear >= @year2 order by movieyear desc;
end
else 
begin
	select * from movieentities where movieyear >= @year1 and movieyear <= @year2 order by movieyear desc;
end
end


alter proc search_category
@cat varchar(20)
as
begin
   select * from movieentities where moviecategory1 LIKE '%'+@cat+'%' or moviecategory2 LIKE '%'+@cat+'%' order by movieyear desc;
end


alter proc search_language
@lang varchar(20)
as
begin
   select * from movieentities where movielanguage LIKE '%'+@lang+'%' order by movieyear desc;
end


create proc search_rating
@rate float
as
begin
   select * from movieentities where movierating > = @rate order by movieyear desc;
end


alter proc search_lead
@lead varchar(20)
as
begin
   select * from movieentities where movielead1 LIKE '%'+@lead+'%' or movielead2 LIKE '%'+@lead+'%' order by movieyear desc;
end

create proc search_year_asc
@year1 int, @year2 int 
as
begin
if(@year1>@year2)
begin
   select * from movieentities where movieyear < = @year1 and movieyear >= @year2 order by movieyear asc;
end
else 
begin
	select * from movieentities where movieyear >= @year1 and movieyear <= @year2 order by movieyear asc;
end
end

create proc search_name_asc
@name varchar(20)
as
begin
   select * from movieentities where moviename LIKE '%'+@name+'%' order by movieyear asc;
end

create proc search_category_asc
@cat varchar(20)
as
begin
   select * from movieentities where moviecategory1 LIKE '%'+@cat+'%' or moviecategory2 LIKE '%'+@cat+'%' order by movieyear asc;
end

create proc search_lead_asc
@lead varchar(20)
as
begin
   select * from movieentities where movielead1 LIKE '%'+@lead+'%' or movielead2 LIKE '%'+@lead+'%' order by movieyear asc;
end

create proc search_language_asc
@lang varchar(20)
as
begin
   select * from movieentities where movielanguage LIKE '%'+@lang+'%' order by movieyear asc;
end

create proc search_rating_asc
@rate float
as
begin
   select * from movieentities where movierating > = @rate order by movieyear asc;
end