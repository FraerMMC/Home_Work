bool checkWorkMachine = true;
string baseCommand = "";
string typeInput = "";
bool checkValidCommand = false;
double balance = 0;
string denomination = "";
string balanceWordEnding = "";
double remainder = 0;
bool cycleEnd = true;
double coinsCount = 0;
int gettingGoodNumber = 0;
int gettingGoodCount = 0;
string exitWord = "";
double numb = 0;

List<string> goodsName = new() {"Cula", "Sipirite", "Paradice pleasure", "Marsiane", "Doshik",
	"Russian Doshik V2.0", "Rat Bull", "Morphine", "Not pringles", "Baltica 9", "Baltica 7", "Baltica 0"};
List<int> goodsCount = new() { 10, 15, 31, 12, 45, 65, 34, 12, 65, 74, 34, 11 };
List<double> goodsCost = new() { 80, 80, 50, 50, 70, 70, 200, 250, 150, 100, 100, 70 };
List<Goods> goods = new() ;
Goods Cula = new Goods("Cula", 10, 80);
Goods Sipirite = new Goods("Sipirite", 15, 80);
Goods ParadicePleasure = new Goods("Paradice pleasure", 31, 50);
Goods Marsiane = new Goods("Marsiane", 12, 50);
Goods Doshik = new Goods("Doshik", 45, 70);
Goods RussianDoshik = new Goods("Russian Doshik V2.0", 65, 70);
Goods RatBull = new Goods("Rat Bull", 34, 200);
Goods Morphine = new Goods("Morphine", 12, 250);
Goods NotPringles = new Goods("Not pringles", 65, 150);
Goods BalticaNine = new Goods("Baltica 9", 74, 100);
Goods BalticaSeven = new Goods("Baltica 7", 34, 100);
Goods BalticaZero = new Goods("Baltica 0", 11, 70);


//Работа машины
while (checkWorkMachine)
{
	Console.WriteLine("Что вы хотите сделать?\n" +
		"(Название команды) - (Команда)\n" +
		"-----------------------------------\n" +
		"Добавить денег - AddMoney\n" +
		"Вернуть сдачу - GetChange\n" +
		"Посмотреть товары - ShowGoods\n" +
		"Купить товар - BuyGood");

	baseCommand = Console.ReadLine();
	baseCommand = baseCommand.ToLower();

	Indent();

	//Выбор команды
	switch (baseCommand)
	{
		case "addmoney":
			Console.WriteLine("Какой тип оплаты выбираете?\n" +
				"(Название комманды) - (Команда)\n" +
				"---------------------------\n" +
				"Карта - Card\n" +
				"Монеты - Coins");
			Indent();
			ValidCommandControl();

			while (checkValidCommand)
			{
				typeInput = Console.ReadLine();
				typeInput = typeInput.ToLower();
				if (typeInput == "card")
				{
					ValidCommandPassed();
					Console.Write("Введите сумму:");
					validNumber();
					balance += numb;

                    checkBalance();
					Indent();
                }
				else if (typeInput == "coins")
				{
					ValidCommandPassed();
					cycleEnd = true;
					while (cycleEnd)
					{
						Console.WriteLine("Выберите номинал монет, которые хотите вставить (Есть только 1, 2, 5, 10).\n" +
							"Если вы больше не хотите пополнять баланс, введите команду \"Stop\".");
						denomination = Console.ReadLine();
						denomination = denomination.ToLower();

						switch (denomination)
						{
							case "1":
								Console.Write("Кол-во монет (Только число): ");
								balance += Convert.ToDouble(Console.ReadLine());

								checkBalance();
								Indent();
								break;

							case "2":
                                Console.Write("Кол-во монет (Только число): ");
                                balance += 2 * Convert.ToDouble(Console.ReadLine());

                                checkBalance();
                                Indent();
                                break;

                            case "5":
                                Console.Write("Кол-во монет (Только число): ");
                                balance += 5 * Convert.ToDouble(Console.ReadLine());

                                checkBalance();
                                Indent();
                                break;

                            case "10":
                                Console.Write("Кол-во монет (Только число): ");
                                balance += 10 * Convert.ToDouble(Console.ReadLine());

                                checkBalance();
                                Indent();
                                break;

                            case "stop":
								cycleEnd = false;
								Indent();
                                break;

                            default:
								Console.WriteLine("Что-то пошло не так, введите команду снова.");
								Indent();
								break;
						}
					}
				}
				else
				{
					Console.WriteLine("Команда неопознана, введите заново.");
				}
			}
			break;

		case "getchange":
			if (balance <= 0)
			{
				Console.WriteLine("На балансе 0 рублей");
                Indent();
                break;
			}
			Console.WriteLine("Идёт возвращение монет...");

			while (balance >= 10)
			{
                coinsCount++;
                balance -= 10;
            }

			Console.WriteLine($"Выданы {coinsCount} монет с номиналом \"10\".");
			coinsCount = 0;

			if (balance >= 5)
			{
				coinsCount++;
				balance -= 5;
			}

            Console.WriteLine($"Выданы {coinsCount} монет с номиналом \"5\".");
			coinsCount = 0;

			if (balance >= 2)
			{
				while (balance >= 2)
				{
					coinsCount++;
					balance -= 2;
				}
			}
            Console.WriteLine($"Выданы {coinsCount} монет с номиналом \"2\".");
            coinsCount = 0;

			if (balance >= 1)
			{
				coinsCount++;
				balance -= 1;
			}

            Console.WriteLine($"Выданы {coinsCount} монет с номиналом \"1\".");
            coinsCount = 0;

			checkBalance();
			Indent();
			break;

		case "showgoods":
			ShowGoods();
			//ShowGoodsClass();
            Indent();
            break;

		case "buygood":

			ValidCommandControl();
            while (checkValidCommand)
			{
                Console.Write("Выберите номер товара (Его можно рассмотреть в списке товаров): ");
				validNumber();
				gettingGoodNumber = Convert.ToInt32(numb);
				if (goodsCount[gettingGoodNumber - 1] <= 0 && gettingGoodNumber <= goodsName.Count && gettingGoodNumber > 0)
				{
					Console.WriteLine("Данный товар закончился.");
				}
                else if (gettingGoodNumber <= goodsName.Count && gettingGoodNumber > 0)
				{
					ValidCommandPassed();
                }
				else
				{
					Console.WriteLine("Неправильный номер товара, посмотрите список товаров и повторите попытку.");
                    ShowGoods();
					Indent();
                }
            }

            ValidCommandControl();
            while (checkValidCommand)
            {
                Console.WriteLine("Выберите количество товара: ");
                validNumber();
                gettingGoodCount = Convert.ToInt32(numb);
                if (gettingGoodCount > 0 && gettingGoodCount <= goodsCount[gettingGoodNumber - 1] && balance - (goodsCost[gettingGoodNumber - 1] * gettingGoodCount) >= 0)
                {
                    ValidCommandPassed();
					goodsCount[gettingGoodNumber - 1] -= gettingGoodCount;
					balance -= goodsCost[gettingGoodNumber - 1] * gettingGoodCount;
					checkBalance();
                }
                else if (gettingGoodCount <= goodsCount[gettingGoodNumber - 1] && balance - (goodsCost[gettingGoodNumber - 1] * gettingGoodCount) < 0)
                {
                    Console.WriteLine("Недостаточно средств. Хотите выйти? (y/n)");
					while (true)
					{
                        exitWord = Console.ReadLine();
						exitWord = exitWord.ToLower();
                        if (exitWord == "y")
                        {
                            ValidCommandPassed();
							break;
                        }
                        else if (exitWord == "n")
                        {
                            break;
                        }
                        else
                        {
							Console.WriteLine("Можно ввести только \"y\" или \"n\".");
    
						}
                    }

                }
				else
				{
					Console.WriteLine("Вы ввели больше товара, чем его есть в автомате");
				}
            }
            break;

		//Секретный код самоуничтожения
		case "killthisshitnowplease":
			checkWorkMachine = false;
			break;

		default:
			Console.WriteLine("Команда не опознана!");
			break;
	}
}

//Отступ
void Indent()
{
	Console.WriteLine();
}

//Проверка команды пройдена
void ValidCommandPassed()
{
	checkValidCommand = false;
}

//Проверить команду
void ValidCommandControl()
{
    checkValidCommand = true;
}

void checkBalance()
{
	remainder = balance;

    while (remainder > 100)
	{
        remainder = remainder % 10;
	}

	if (remainder >= 11 && remainder <= 14)
	{
		balanceWordEnding = "рублей";
	}
	else if (remainder % 10 == 0)
	{
        balanceWordEnding = "рублей";
    }
	else if (remainder % 10 == 1) 
	{
        balanceWordEnding = "рубль";
    }
    else if (remainder % 10 >= 2 && remainder % 10 <= 4)
    {
        balanceWordEnding = "рубля";
    }
    else if (remainder % 10 >= 5 && remainder % 10 <= 9)
    {
        balanceWordEnding = "рублей";
    }
	Console.WriteLine($"На вашем балансе {balance} {balanceWordEnding}");
}

void ShowGoods()
{
    for (int i = 0; i < goodsName.Count; i++)
    {
        Console.WriteLine($"Название товара: {goodsName[i]} ({i + 1}).|| Кол-во в автомате: {goodsCount[i]}.|| Цена: {goodsCost[i]}");
    }
}

//void ShowGoodsClass()
//{
//    foreach (var good in goods)
//    {
//        Console.WriteLine($"Название товара: {good._goodName}.|| Кол-во в автомате: {good._goodCount}.|| Цена: {good._goodCost}");
//    }
//}

void validNumber()
{
    cycleEnd = true;
    while (cycleEnd)
    {
        int.TryParse(Console.ReadLine(), out int value);
        if (value <= 0)
        {
            Console.WriteLine("Введено неверное число!");
        }
        else
        {
            cycleEnd = false;
			numb = value;
        }
    }
}
