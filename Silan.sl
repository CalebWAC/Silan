println("Guess the number!");

print("Input a number: ")
var int num = readLine();

var int guesses = 2;

while (num != 10) {
    println("That is not the correct number. ");
    print("Guess: ");
    num = readLine();
    guesses++
}

println("That was correct!");

if (guesses <= 5) {
    print("That took skill! You did it in only ");
    print(guesses);
    println(" guesses!");
}

if (guesses > 5) {
    print("Nice work! You did it in ");
    print(guesses);
    println(" guesses!");
}