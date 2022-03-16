#define COMPILATIONCONDITION
using System.Diagnostics;
using System.Globalization;
using System.Text;

class Program
{
    static void CheckIfIsNumber(object no)
    {
        if (no.GetType() != typeof(int))
            throw new NotAnIntException("The object is not a integer.");
    }

    static void CheckIfIsPositive(object no)
    {
        if ((int)no <= 0)
            throw new InvalidNumberException("Number is not positive.");
    }

    static void CheckIfIsZero(object no)
    {
        if ((int)no == 0)
            throw new InvalidNumberException("Number is equal to 0.");
    }

    static void CheckIfIsNegative(object no)
    {
        if ((int)no > 0)
            throw new InvalidNumberException("Number is not negative.");
    }

    static void Main(string[] args)
    {
        var n = "gja";
        try
        {
            CheckIfIsNumber(n);
            CheckIfIsNegative(n);
        } catch (InvalidNumberException ex)
        {
            Log(ex);
            throw new Exception("Look in inner ex.", ex);
        } catch (NotAnIntException ex)
        {
            Log(ex);
            Debug.WriteLine("Exception stack trace: ");
            Debug.WriteLine(ex.StackTrace);
            Debug.WriteLine("Exception message: ");
            Debug.WriteLine(ex.Message);
        }catch(Exception ex)
        {
            Log(ex);
            throw;
        }

        int[] arr = { 1, 2, 3, 0, 4, 5, 0 };

        double result = 0;
        try
        {
            result = DoSomething(2, 1 , arr);
        }
        catch(IndexOutOfRangeException ex)
        {
            Log(ex);
        }
        catch (LogBaseException ex)
        {
            Log(ex);
        }
        catch (LogArgumentException ex)
        {
            Log(ex);
        }
        finally
        {
            Console.WriteLine($"The result is {result}");
        }

#if DEBUG && COMPILATIONCONDITION
        Console.WriteLine("This happens in debug mode only when we have COMPILATIONCONDITION defined");
#endif

#if RELEASE && COMPILATIONCONDITION
        Console.WriteLine("This happens in release mode only when we have COMPILATIONCONDITION defined in debug mode");
#endif
    }

    public static double DoSomething(int idx1, int idx2, int[] arr)
    {
        if (idx1 < 0 || idx2 < 0)
            throw new IndexOutOfRangeException("Indexes cannot be negative");
        int length = arr.Length;
        if (idx1 >= length || idx2 >= length)
            throw new IndexOutOfRangeException("Indexes can't be greater than array length");
        int logBase = arr[idx2];
        int argument = arr[idx1];
        if (logBase == 1)
            throw new LogBaseException("Logarithm base cannot be 1");
        if (logBase <= 0)
            throw new LogBaseException("Logarithm base cannot be less than 0");
        if (argument <= 0)
            throw new LogArgumentException("Logarithm argument cannot be less than 0");
        return Math.Log(argument, logBase);
    }

    private static void Log(Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}