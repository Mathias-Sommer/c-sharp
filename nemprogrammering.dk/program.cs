//All assignments completed from nemprogrammering.dk C# tutorial

/*
//#Opgave 1
//Console.WriteLine("Enkelt linie kommentar");
//Console.Write("Skifter ikke linie med denne kommentar");

Console.WriteLine("Jeg er din første kommentar, hurra!");
Console.Write("jeg bestemmer selv kommentaren her!");
Console.WriteLine("Hello world!");

//#Opgave 2
int x = 5;
int y = 3;

Console.WriteLine("X er " + x + " Y er " + y);

//#Opgave 3
int INT = 10;
double DOUBLE = 10.50;
char CHAR = 'a';
Console.WriteLine(INT);    // heltal kan ikke tage komma
Console.WriteLine(DOUBLE); // kommatal kan tage tal med komma 
Console.WriteLine(CHAR);   // kun karaktere, fx A, B eller C



//#Opgave 4
string tekst1 = "Hej med dig. Jeg er en smart variable type!";
double penge = 200.50;
string tekst2 = " Jeg har: ";
string tekst3 = " kr. i banken.";
Console.Write(tekst1 + tekst2 + penge + tekst3);


//#Opgave 5
// 1. % er modulus og er resten når man dividere. 5 divideret med 3 er modulus 2.
//int x = 5 % 3;
//Console.WriteLine(x);

// 2. Hvilke af følgende udtryk må man ikke lave, og hvorfor?
//int x = 2 / 2;
//int y = 2 / 1;
//int z = 2 / 0; <--- denne, da man aldrig må dividere med 0.

//3 Prøv selv at udregne følgende matematiske udtryk, og lav derefter et program der udregner dem for dig,
//  og gemmer deres værdi i en variabel som du kan udskrive:
//  2 + 1 * 2
//  (2 + 1) * 2
//  5 / 2
//  8 % 3
//  1 - 5
int x = 2 + 1 * 2;
Console.WriteLine(x);
int y = (2 + 1) * 2;
Console.WriteLine(y);
int z = 5 / 2;
Console.WriteLine(z);
int a = 8 % 3;
Console.WriteLine(a);
int b = 1 - 5;
Console.WriteLine(b);

//#Opgave 6
// 1. (2 gider jeg ikke er det samme)
int a = 10;
int b = 20;
int c = 30;
int result = a - b + c;
Console.WriteLine(result);


//#Opgave 7
// 1. tæl counter op med 5
int counter = 0;
counter += 5;
Console.WriteLine(counter);

//2.  tæl conter op med en
counter = 0;
counter += 5;
Console.WriteLine(counter);

//3. hvad er forskellen på counter++; og ++counter;
// forskellen er om den tæller op før counter eller efter. fx:
// console.writeline(++counter); hvis counter var 1, udskriver den også 1.
// console.writeline(counter++); hvis counter var 1, udskriver den 2.

//#Opgave 8
// booelan
int x = 10;
int y = 20;

bool test = x > y;
Console.WriteLine(test);

if (test) { // hvis test er true sker det her, hvis false springer den over.
    Console.WriteLine("udskriver kun ved true.");
}

//#Opgave 9
//1.
int a = 42;
int b = 64;

if (a + b > 100){
    Console.Write("Summen er større end 100! Summen er: " + (a + b));        
}

//2. dice game Standard version :)
int dice = 0;
if (dice == 1) {
    Console.WriteLine("Ener");
    }
else if (dice == 2) {
    Console.WriteLine("Toer");
    }
else if(dice == 3) {
    Console.WriteLine("Tre");
    }
else if(dice == 4) {
    Console.WriteLine("Fire");
    }
else if(dice == 5) {
    Console.WriteLine("Fem");
    }
else if(dice == 6) {
    Console.WriteLine("Seks");
    }
else {
    Console.WriteLine("Magisk terning?");
    }


//2. dice game et faktisk spil ;)
int dice = 0;
bool loop;
Console.Write("Vil du kaste med terningen? Ja/Nej: ");
string start = Console.ReadLine();
    if(start == "Ja" || start == "ja") {
    loop = true;
        while(loop) {
            Console.Write("Angiv et tal mellem 1-6 inklusiv: ");
            dice = Convert.ToInt32(Console.ReadLine());
            if(dice == 1) {
                Console.WriteLine("Du slog: Ener");
                }
            else if(dice == 2) {
                Console.WriteLine("Du slog: Toer");
                }
            else if(dice == 3) {
                Console.WriteLine("Du slog: Tre");
                }
            else if(dice == 4) {
                Console.WriteLine("Du slog: Fire");
                }
            else if(dice == 5) {
                Console.WriteLine("Du slog: Fem");
                }
            else if(dice == 6) {
                Console.WriteLine("Du slog: Seks");
                }
            else {
                Console.WriteLine("Magisk terning?");
                }
                Console.WriteLine("Vil du prøve igen? Ja/Nej: ");
                start = Console.ReadLine();
                    if (start == "Ja" || start == "ja") {
                        continue;
                        } 
                    else {
                        break;
                        }
                }
        }
    else {
        Console.WriteLine("Træls for dig.");
        }


// Opgave 11 switch sætninger 
int dice = 6;
switch(dice) {
    case 1: 
        Console.WriteLine("Ener");
        break;
    case 2: 
        Console.WriteLine("To");
        break;
    case 3:
        Console.WriteLine("Tre");
        break;
    case 4:
        Console.WriteLine("Fire");
        break;
    case 5:
        Console.WriteLine("Femmer");
        break;
    case 6:
        Console.WriteLine("Sekser");
        break;
    default:
        Console.WriteLine("Magisk terning?");
        break;
    }

// opgave 12
//1. Lav et program, der udskriver tallene fra 1 til 100 inklusiv. Lav opgaven både med en while og en for-loop.

// while loop
int i = 1;
while(i <= 100) {
    Console.WriteLine(i++);
    }

// for loop
for(int i = 1; i <= 100; i++) {
    Console.WriteLine(i);
    }

//2. Ændre opgave 1, så den tæller fra 100 til 1 (igen, både med for og while loop).
//while loop
int i = 100;
while (i >= 1) {
    Console.WriteLine(i--);
    }

// for loop
for(int i = 100; i >= 1; i--) {
    Console.WriteLine(i);
    }

//3. Lav en for-loop, der udskriver den lille 5 tabel (altså 5, 10, 15 ....... 50).
// for loop
for (int i = 5; i <= 50; i += 5) {
    Console.WriteLine(i);
    }

// opgave 13 udvidet kontrolstruktur
//1. Find den største værdi af 3 int variabler, og udskriv denne.
int x = 70;
int y = 60;
int z = 4;

if (x > y && x > z) {
    Console.WriteLine("X er størst");
    }
else if (y > x && y > z) {
    Console.WriteLine("Y er størst");
    }
else if (z > x && z > y) {
    Console.WriteLine("Z er størst");
    }


//2. Lav en loop, der udskriver alle lige tal mellem 0 og 20
//  (brug continue til at overspringe de værdier der ikke skal udprintes).
for (int i = 0; i<= 20; i++){
    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 19) {
        continue;
        }
    Console.WriteLine(i);
    }

for (int i = 0; i<= 20; i += 2) {
    Console.WriteLine(i);
    } */

