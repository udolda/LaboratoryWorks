import java.util.Map;
import java.util.HashMap;
import java.util.TreeMap;
import java.util.Scanner;
import java.util.ArrayList;
import DiffSpelling.Print.*;

public class Main
{
    //region Поля_Класса
    static Scanner inp =new Scanner(System.in);
    static HashMap<Character, String> codes = new HashMap<Character, String>();
    final static String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    final static int div = 6;
    final static int Byte = 8;
    //endregion

    public static void main(String[] args)
    {
        int menuItem = 0;

        while (menuItem != 7)
        {
            System.out.println
                    (
                            //region Меню
                            "1) Исправление сообщения.\n" +
                                    "2) Транслитерация.\n" +
                                    "3) Обрезание строки.\n" +
                                    "4) \n" +
                                    "5) Различные написания строки.\n" +
                                    "6) Кодирование/Декодирование MIME.\n" +
                                    "7) Выход."
                            //endregion
                    );

            menuItem = inp.nextInt();

            switch (menuItem)
            {
                case 1:
                {
                    System.out.print("Переданное сообщение: ");
                    String msg;
                    inp.nextLine();
                    msg = inp.nextLine();

                    System.out.println("Исходное сообщение: " + resOrigMess(msg));
                }
                break;

                case 2:
                {
                    System.out.print("Задайте строку для транслитерации: ");
                    inp.nextLine();
                    String msg = inp.nextLine();

                    System.out.println(transliteration(msg));
                }
                break;

                case 3:
                {
                    System.out.print("Задайте строку для обрезания: ");
                    inp.nextLine();
                    String msg = inp.nextLine();

                    System.out.println("Обрезанная строка: " + truncate(msg,10));
                }
                break;

                case 4:
                {

                }
                break;

                case 5:
                {
                    System.out.print("Задайте строку: ");
                    inp.nextLine();
                    String msg = inp.nextLine();


                    System.out.println(
                            //region Подменю_начертания
                            "1) Как в предложении.\n" +
                                    "2) все строчные\n" +
                                    "3) ВСЕ ПРОПИСНЫЕ\n" +
                                    "4) Начинать С Прописных\n" +
                                    "5) иЗМЕНИТЬ РЕГИСТР"
                            //endregion
                        );

                    var strings = new ArrayList<BasePrint>();
                    strings.add(new SentencePrint());
                    strings.add(new LowerPrint());
                    strings.add(new UpperPrint());
                    strings.add(new UpperFirstPrint());
                    strings.add(new InversePrint());

                    switch (inp.nextInt())
                    {
                        case 1: strings.get(0).Display(); strings.get(0).PrintString(msg); break;
                        case 2: strings.get(1).Display(); strings.get(1).PrintString(msg); break;
                        case 3: strings.get(2).Display(); strings.get(2).PrintString(msg); break;
                        case 4: strings.get(3).Display(); strings.get(3).PrintString(msg); break;
                        case 5: strings.get(4).Display(); strings.get(4).PrintString(msg); break;
                        default: System.out.println("Данного пункта меню не существует.");
                    }

                }
                break;

                case 6:
                {
                    System.out.print("Задайте строку для кодирования: ");
                    inp.nextLine();
                    String msg = inp.nextLine();

                    var result = Encoding(msg);
                    System.out.println("Кодирование: " + result);
                    System.out.println("Декодирование: " + Decoding(result));
                }
                break;

                case 7:
                {
                    System.exit(0);
                }
                break;

                default:
                {
                    System.out.println("Данного пункта меню не существует.");
                }
            }
        }
    }

    //Метод. 1 задание. Восстановление исходного сбщ.
    private static String resOrigMess(String receivMess)
    {
        String res = "";
        byte[] bit = {0, 0};

        for (int i = 0; i < receivMess.length(); i++)
        {
            if(receivMess.charAt(i) =='0') bit[0]++;
            else bit[1]++;

            if((i+1)%3 == 0)
            {
                if(bit[0] > bit[1]) res += '0';
                else res += '1';

                bit[0] = 0; bit[1] = 0;
            }
        }

        return res;
    }

    //Метод. 2 задание. Транслитерация.
    private  static String transliteration(String message)
    {
        String res="";

        Map<String, String> dict = new TreeMap<>();
        //Map<String, String> dict = Map.of("а","a","б","b","в","v","г","g","д","d","е","e","ё","e","ж","zh","з","z","и","i");
        //Map <String,String>dict1=Map.ofEntries(Map.entry("f","f"));
        //Map.Entry<String,String> entry = Map.ofEntries("а","b");
        {
            dict.put("а","a");
            dict.put("б","b");
            dict.put("в","v");
            dict.put("г","g");
            dict.put("д","d");
            dict.put("е","e");
            dict.put("ё","e");
            dict.put("ж","zh");
            dict.put("з","z");
            dict.put("и","i");
            dict.put("й","i");
            dict.put("к","k");
            dict.put("л","l");
            dict.put("м","m");
            dict.put("н","n");
            dict.put("о","o");
            dict.put("п","p");
            dict.put("р","r");
            dict.put("с","s");
            dict.put("т","t");
            dict.put("у","u");
            dict.put("ф","f");
            dict.put("х","h");
            dict.put("ц","c");
            dict.put("ч","ch");
            dict.put("ш","sh");
            dict.put("щ","sh");
            dict.put("ъ","");
            dict.put("ы","i");
            dict.put("ь","");
            dict.put("э","e");
            dict.put("ю","yu");
            dict.put("я","ya");
        }
        //"а": "a", "б": "b", "в": "v", "г": "g", "д": "d", "е": "e", "ё": "e", "ж": "zh", "з": "z", "и": "i", "й": "i", "к": "k", "л": "l", "м": "m", "н": "n", "о": "o", "п": "p", "р": "r", "с": "s", "т": "t", "у": "u", "ф": "f", "х": "h", "ц": "c", "ч": "ch", "ш": "sh", "щ": "sh'", "ъ": "", "ы": "i", "ь": "", "э": "e", "ю": "yu", "я": "ya".

        for (int i = 0; i < message.length(); i++)
        {
            if(dict.containsKey(Character.toString(message.charAt(i)).toLowerCase())/* && i!=0 && message.charAt(i - 1)!= ' '*/) res += dict.get(Character.toString(message.charAt(i)).toLowerCase());
            //else if (dict.containsKey(Character.toString(message.charAt(i)).toLowerCase()) && (i==0 || message.charAt(i)!= ' ')) res += dict.get(Character.toString(message.charAt(i)).toLowerCase()).toUpperCase();
            else res += message.charAt(i);
        }


        res = res.replace(res.charAt(0),Character.toUpperCase(res.charAt(0)));
        int i = 1;
        while (res.charAt(i-1) != ' ') i++;
        res = res.replace(res.charAt(i),Character.toUpperCase(res.charAt(i)));

        return res;
    }

    //Метод. 3 задание. Стандартное обрезание 16с.
    private  static String truncate(String message)
    {
        return truncate(message,16);
    }

    //Метод. 3 задание. Обрезание до n-го символа.
    private  static String truncate(String message, int n)
    {
        int spToEr = 1;
        while (message.endsWith(" "))
        {
            message = message.substring(0, message.length() - spToEr);
            spToEr++;
        }

        if (message.length() > n)
        {
            message = message.substring(0, n);
            while (message.endsWith(" "))
            {
                message = message.substring(0, n - spToEr);
                spToEr++;
            }
            message += "...";
        }

        return  message;
    }

    //Метод. Добавляет нули до байта.
    private static String AddZero(String str)
    {
        while (str.length() != Byte) str = "0" + str;
        return str;
    }

    //Метод. 6 задание. Кодирование MIME.
    private static String Encoding(String str)
    {
        var binStr = "";
        for (var i = 0; i < str.length(); i++)
        {
            var cur = str.charAt(i);
            binStr += AddZero(Integer.toBinaryString(Integer.valueOf(cur)));
        }

        var res = binStr.length() % div;
        if (res != 0)
        {
            for (var i = 0; i < div - res; i++) binStr += "0";
        }

        var j = 0;
        var result = "";
        for (var i = 0; i < binStr.length(); i+=div)
        {
            var cur = binStr.substring(i, i + div);
            var code = alphabet.charAt(Integer.parseInt(cur, 2));
            result += code;
            codes.put(code, cur);
        }
        return result;
    }

    //Метод. 6 задание. Декодирование MIME.
    private static String Decoding(String str)
    {
        var binStr = "";
        for (var i = 0; i < str.length(); i++) binStr += codes.get(str.charAt(i));

        var result = "";
        for (var i = 0; i < binStr.length() - div + 1; i+=Byte)
        {
            var codeValue = Integer.parseInt(binStr.substring(i, i + Byte), 2);
            result += (char)codeValue;
        }

        return result;
    }

}
