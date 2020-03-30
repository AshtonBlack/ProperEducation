import java.util.Scanner;

public class HelloIdea {
    public static void main(String args[]){
        Scanner scan = new Scanner(System.in);

        String codename = "lord";
        int age = 30;

        System.out.println("Who r u?");
        String message = scan.nextLine();
        if(codename.intern() == message.intern()){
            System.out.println("Glad to see u!");
        }

        System.out.println("How old r u?");
        int urAge = scan.nextInt();
        if(urAge == age){
            System.out.println("Right!");
        }
    }
}
