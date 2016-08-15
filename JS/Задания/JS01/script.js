/**
 * Created by admin on 15.08.2016.
 */
var surname = "";
var sex = "";
var age = "";
var email = "";
do
{
    surname=prompt("Ваша фамилия:");
    sex=prompt("Ваш пол:");
    age=prompt("Ваш возраст:");
    email=prompt("Ваш адрес электронной почты:");

}
while(!(confirm("ФИО: "+surname+"\n" +
    "Пол: "+sex+"\n" +
    "Возраст: "+age+"\n" +
    "Е-mail: "+email+"\n\n" +
    "Все верно?")))
alert("Благодарим за предоставленную информацию");

