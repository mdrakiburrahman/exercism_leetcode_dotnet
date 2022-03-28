using System;

public static class RnaTranscription
{
    public static string ToRna(string dna)
    {
        var rna = "";

        switch (dna.Length) 
        {
            case 0:
                return rna;
            default:
                foreach (var value in dna)
                {
                    switch (value)
                    {
                        case 'G':
                            rna += "C";
                            break;
                        case 'C':
                            rna += "G";
                            break;
                        case 'T':
                            rna += "A";
                            break;
                        case 'A':
                            rna += "U";
                            break;
                    }
                }
                return rna;
        }
    }
}