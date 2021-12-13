# Silan Programming Language
Silan (short for SImple LANguage) is a programming language designed to be an auxilary programming language. Its syntax was built off of C++, C#, Java, JavaScript, Python, Ruby, Kotlin, Swift, Go, and Dart.


# Sample Code:
```Go
// This is a comment
/* This is a block comment
Semicolons are recommended, but not necessary */

// func main() is recommended to surround code, but not necessary
func main() {
  print("Hello World");
  
  var variable = "value";
  var int variableWithType = 0;
  /* Types:
   - string
   - bool
   - int
   - char
   - float
  */
  
  if (1 == 1) {
    print("1 is equal to 1");
  } else if (1 != 1) {
    print("1 is not equal to 1);
  } else {
    print("1 is a mysterious number");
  }
  
  var int number = 2;
  switch (number) {
    case 1:
      print("Its 1");
      break; // break keyword is recommended, but not required
    case 2:
      print("Its 2");
      break;
    default:
      print("It is not 1 nor 2");
      break;
   }
   
   while (number < 8) {
    print(number);
   }
   
   do {
    print(number);
    if (number == 2) {
      continue;
    }
   } while (number < 8)
   
   for (var i = 0; i < 10; i++) {
    print(i);
   }
   
   for (element in array) {
    print(element);
   }
   
   
}

func bool add(int number1, int number2) {
  return number1 * number2;
}```
