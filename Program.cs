using System.Diagnostics;

namespace ThreadsHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ==========Min In Array============
            int[] array = { 2, 3, 4, 10, 12, 45, 12, 11, 22, 23, 1 };

            var minProcessor = new MinInArray<int>(3, array); //Best count of Threads.

            minProcessor.Process();

            Console.WriteLine($"Minimum value: {minProcessor.Min}");


            //============Max In Array=================

            var maxProcessor = new MaxInArray<int>(7, array); //Best count of Threads.

            var sv = Stopwatch.StartNew();

            maxProcessor.Process();


            //============Sum Of Array=================

            var sumProcessor = new SumArray(4, array); //Best count of Threads.

            sumProcessor.Process();


            // ===========Average In Array=============

            var averageProcessor = new AverageInArray(4, array); //Best count of Threads.

            double average = averageProcessor.GetAverage();


            // ===========Copy Part Of Array===========

            ArrayCopy<int> arrayCopy = new ArrayCopy<int>(3, array); //Best count of Threads.

            arrayCopy.Process();

            int[] copiedArray = arrayCopy.GetCopiedArray();

            // ===========Symbol Frequency=============
            char[] charArray = "The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox. Bright vixens jump; dozy fowl quack. Quick wafting zephyrs vex bold Jim. Quick zephyrs blow, vexing daft Jim. Sex-charged fop blew my junk TV quiz. How quickly daft jumping zebras vex. Two driven jocks help fax my big quiz. Quick, Baz, get my woven flax jodhpurs! \"Now fax quiz Jack!\" my brave ghost pled. Five quacking zephyrs jolt my wax bed. Flummoxed by job, kvetching W. zaps Iraq. Cozy sphinx waves quart jug of bad milk. A very bad quack might jinx zippy fowls. Few quips galvanized the mock jury box. Quick brown dogs jump over the lazy fox. The jay, pig, fox, zebra, and my wolves quack! Blowzy red vixens fight for a quick jump. Joaquin Phoenix was gazed by MTV for luck. A wizard’s job is to vex chumps quickly in fog. Watch \"Jeopardy!\", Alex Trebek's fun TV quiz game. Woven silk pyjamas exchanged for blue quartz. Brawny gods just".ToCharArray();

            var charFrequencyProcessor = new GetCharFrequency(4, charArray); //Best count of Threads.

            charFrequencyProcessor.Process();

            var frequencyCharDict = charFrequencyProcessor.GetFrequency();



            // ===========Word Frequency===============
            string text = "The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox. Bright vixens jump; dozy fowl quack. Quick wafting zephyrs vex bold Jim. Quick zephyrs blow, vexing daft Jim. Sex-charged fop blew my junk TV quiz. How quickly daft jumping zebras vex. Two driven jocks help fax my big quiz. Quick, Baz, get my woven flax jodhpurs! \"Now fax quiz Jack!\" my brave ghost pled. Five quacking zephyrs jolt my wax bed. Flummoxed by job, kvetching W. zaps Iraq. Cozy sphinx waves quart jug of bad milk. A very bad quack might jinx zippy fowls. Few quips galvanized the mock jury box. Quick brown dogs jump over the lazy fox. The jay, pig, fox, zebra, and my wolves quack! Blowzy red vixens fight for a quick jump. Joaquin Phoenix was gazed by MTV for luck. A wizard’s job is to vex chumps quickly in fog. Watch \"Jeopardy!\", Alex Trebek's fun TV quiz game. Woven silk pyjamas exchanged for blue quartz. Brawny gods just";

            char[] separators = { ' ', ',', '.', ';', ':', '?', '!' };
            var wordsArray = text.Split(separators).Where(w => w != "").ToArray();

            var wordFrequencyProcessor = new GetWordFrequency(2, wordsArray); //Best count of Threads.

            wordFrequencyProcessor.Process();

            var frequencyWordDict = wordFrequencyProcessor.GetFrequency();
        }
    }
}
