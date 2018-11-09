import java.util.stream.Stream;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		   int num = 0;
           Integer a = createNumA(num);
           num = a;
           Number b = createNumB(a);
           
           if (a==b)
           {
               num += num++ + num-- - 1;
           }
           else
           {
               num += num++ + num-- + num--;
           }
			
			switch(num)
			{
			case 6:
				System.out.println("Answer: Capgemini");
				break;
			case 7:
				System.out.println("Answer: znak");
				break;
			case 9:
				System.out.println("Answer: Java");
				break;
			default:
				throw new RuntimeException();
			}
	}
    private static Integer createNumA(Integer x)
    {
        return ++x<<1;
    }

    private static Number createNumB(Number num)
    {
        return calculate(Stream.of(num));
    }
	
	private static Number calculate(Stream<Number> number)
	{
		try
		{
			return number.findFirst().get();
		}
		catch(Exception exception)
		{
			throw new AreYouSureException();
		}
	}
	
	private static class AreYouSureException extends RuntimeException
	{
		private AreYouSureException(){
			super("O RLY?");
		}
	}

}
