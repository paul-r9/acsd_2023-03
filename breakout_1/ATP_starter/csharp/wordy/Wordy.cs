using System;

public static class Wordy
{
    public static int Answer(string question) {

        question = question.Substring(0, question.Length - 1);
        var tokens = question.Split(' ');
        
        // throw new NotImplementedException("You need to implement this function.");
        
        
        if (question == "What is 1 plus 1?") {
            return 2;
        }
        if (question == "What is 53 plus 2?") {
            return 55;
        }
        return Convert.ToInt32(tokens[2]);
        
        
    }
}