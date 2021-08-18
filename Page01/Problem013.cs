﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=13
     * Title: Large sum
     * Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
     * 
     * 37107287533902102798797998220837590246510135740250
     * 46376937677490009712648124896970078050417018260538
     * 74324986199524741059474233309513058123726617309629
     * 91942213363574161572522430563301811072406154908250
     * 23067588207539346171171980310421047513778063246676
     * 89261670696623633820136378418383684178734361726757
     * 28112879812849979408065481931592621691275889832738
     * 44274228917432520321923589422876796487670272189318
     * 47451445736001306439091167216856844588711603153276
     * 70386486105843025439939619828917593665686757934951
     * 62176457141856560629502157223196586755079324193331
     * 64906352462741904929101432445813822663347944758178
     * 92575867718337217661963751590579239728245598838407
     * 58203565325359399008402633568948830189458628227828
     * 80181199384826282014278194139940567587151170094390
     * 35398664372827112653829987240784473053190104293586
     * 86515506006295864861532075273371959191420517255829
     * 71693888707715466499115593487603532921714970056938
     * 54370070576826684624621495650076471787294438377604
     * 53282654108756828443191190634694037855217779295145
     * 36123272525000296071075082563815656710885258350721
     * 45876576172410976447339110607218265236877223636045
     * 17423706905851860660448207621209813287860733969412
     * 81142660418086830619328460811191061556940512689692
     * 51934325451728388641918047049293215058642563049483
     * 62467221648435076201727918039944693004732956340691
     * 15732444386908125794514089057706229429197107928209
     * 55037687525678773091862540744969844508330393682126
     * 18336384825330154686196124348767681297534375946515
     * 80386287592878490201521685554828717201219257766954
     * 78182833757993103614740356856449095527097864797581
     * 16726320100436897842553539920931837441497806860984
     * 48403098129077791799088218795327364475675590848030
     * 87086987551392711854517078544161852424320693150332
     * 59959406895756536782107074926966537676326235447210
     * 69793950679652694742597709739166693763042633987085
     * 41052684708299085211399427365734116182760315001271
     * 65378607361501080857009149939512557028198746004375
     * 35829035317434717326932123578154982629742552737307
     * 94953759765105305946966067683156574377167401875275
     * 88902802571733229619176668713819931811048770190271
     * 25267680276078003013678680992525463401061632866526
     * 36270218540497705585629946580636237993140746255962
     * 24074486908231174977792365466257246923322810917141
     * 91430288197103288597806669760892938638285025333403
     * 34413065578016127815921815005561868836468420090470
     * 23053081172816430487623791969842487255036638784583
     * 11487696932154902810424020138335124462181441773470
     * 63783299490636259666498587618221225225512486764533
     * 67720186971698544312419572409913959008952310058822
     * 95548255300263520781532296796249481641953868218774
     * 76085327132285723110424803456124867697064507995236
     * 37774242535411291684276865538926205024910326572967
     * 23701913275725675285653248258265463092207058596522
     * 29798860272258331913126375147341994889534765745501
     * 18495701454879288984856827726077713721403798879715
     * 38298203783031473527721580348144513491373226651381
     * 34829543829199918180278916522431027392251122869539
     * 40957953066405232632538044100059654939159879593635
     * 29746152185502371307642255121183693803580388584903
     * 41698116222072977186158236678424689157993532961922
     * 62467957194401269043877107275048102390895523597457
     * 23189706772547915061505504953922979530901129967519
     * 86188088225875314529584099251203829009407770775672
     * 11306739708304724483816533873502340845647058077308
     * 82959174767140363198008187129011875491310547126581
     * 97623331044818386269515456334926366572897563400500
     * 42846280183517070527831839425882145521227251250327
     * 55121603546981200581762165212827652751691296897789
     * 32238195734329339946437501907836945765883352399886
     * 75506164965184775180738168837861091527357929701337
     * 62177842752192623401942399639168044983993173312731
     * 32924185707147349566916674687634660915035914677504
     * 99518671430235219628894890102423325116913619626622
     * 73267460800591547471830798392868535206946944540724
     * 76841822524674417161514036427982273348055556214818
     * 97142617910342598647204516893989422179826088076852
     * 87783646182799346313767754307809363333018982642090
     * 10848802521674670883215120185883543223812876952786
     * 71329612474782464538636993009049310363619763878039
     * 62184073572399794223406235393808339651327408011116
     * 66627891981488087797941876876144230030984490851411
     * 60661826293682836764744779239180335110989069790714
     * 85786944089552990653640447425576083659976645795096
     * 66024396409905389607120198219976047599490197230297
     * 64913982680032973156037120041377903785566085089252
     * 16730939319872750275468906903707539413042652315011
     * 94809377245048795150954100921645863754710598436791
     * 78639167021187492431995700641917969777599028300699
     * 15368713711936614952811305876380278410754449733078
     * 40789923115535562561142322423255033685442488917353
     * 44889911501440648020369068063960672322193204149535
     * 41503128880339536053299340368006977710650566631954
     * 81234880673210146739058568557934581403627822703280
     * 82616570773948327592232845941706525094512325230608
     * 22918802058777319719839450180888072429661980811197
     * 77158542502016545090413245809786882778948721859617
     * 72107838435069186155435662884062257473692284509516
     * 20849603980134001723930671666823555245252804609722
     * 53503534226472524250874054075591789781264330331690
     **************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem013 : ProblemBase
    {
        protected override long ExpectedAnswer => 5537376230;

        private const long CARRY = 1000000000000000000L;

        private readonly long[][] NUMBERS = new long[][] {
            new long[] { 590246510135740250L, 102798797998220837L, 37107287533902L },
            new long[] { 078050417018260538L, 009712648124896970L, 46376937677490L },
            new long[] { 058123726617309629L, 741059474233309513L, 74324986199524L },
            new long[] { 811072406154908250L, 161572522430563301L, 91942213363574L },
            new long[] { 047513778063246676L, 346171171980310421L, 23067588207539L },
            new long[] { 684178734361726757L, 633820136378418383L, 89261670696623L },
            new long[] { 621691275889832738L, 979408065481931592L, 28112879812849L },
            new long[] { 796487670272189318L, 520321923589422876L, 44274228917432L },
            new long[] { 844588711603153276L, 306439091167216856L, 47451445736001L },
            new long[] { 593665686757934951L, 025439939619828917L, 70386486105843L },
            new long[] { 586755079324193331L, 560629502157223196L, 62176457141856L },
            new long[] { 822663347944758178L, 904929101432445813L, 64906352462741L },
            new long[] { 239728245598838407L, 217661963751590579L, 92575867718337L },
            new long[] { 830189458628227828L, 399008402633568948L, 58203565325359L },
            new long[] { 567587151170094390L, 282014278194139940L, 80181199384826L },
            new long[] { 473053190104293586L, 112653829987240784L, 35398664372827L },
            new long[] { 959191420517255829L, 864861532075273371L, 86515506006295L },
            new long[] { 532921714970056938L, 466499115593487603L, 71693888707715L },
            new long[] { 471787294438377604L, 684624621495650076L, 54370070576826L },
            new long[] { 037855217779295145L, 828443191190634694L, 53282654108756L },
            new long[] { 656710885258350721L, 296071075082563815L, 36123272525000L },
            new long[] { 265236877223636045L, 976447339110607218L, 45876576172410L },
            new long[] { 813287860733969412L, 860660448207621209L, 17423706905851L },
            new long[] { 061556940512689692L, 830619328460811191L, 81142660418086L },
            new long[] { 215058642563049483L, 388641918047049293L, 51934325451728L },
            new long[] { 693004732956340691L, 076201727918039944L, 62467221648435L },
            new long[] { 229429197107928209L, 125794514089057706L, 15732444386908L },
            new long[] { 844508330393682126L, 773091862540744969L, 55037687525678L },
            new long[] { 681297534375946515L, 154686196124348767L, 18336384825330L },
            new long[] { 717201219257766954L, 490201521685554828L, 80386287592878L },
            new long[] { 095527097864797581L, 103614740356856449L, 78182833757993L },
            new long[] { 837441497806860984L, 897842553539920931L, 16726320100436L },
            new long[] { 364475675590848030L, 791799088218795327L, 48403098129077L },
            new long[] { 852424320693150332L, 711854517078544161L, 87086987551392L },
            new long[] { 537676326235447210L, 536782107074926966L, 59959406895756L },
            new long[] { 693763042633987085L, 694742597709739166L, 69793950679652L },
            new long[] { 116182760315001271L, 085211399427365734L, 41052684708299L },
            new long[] { 557028198746004375L, 080857009149939512L, 65378607361501L },
            new long[] { 982629742552737307L, 717326932123578154L, 35829035317434L },
            new long[] { 574377167401875275L, 305946966067683156L, 94953759765105L },
            new long[] { 931811048770190271L, 229619176668713819L, 88902802571733L },
            new long[] { 463401061632866526L, 003013678680992525L, 25267680276078L },
            new long[] { 237993140746255962L, 705585629946580636L, 36270218540497L },
            new long[] { 246923322810917141L, 174977792365466257L, 24074486908231L },
            new long[] { 938638285025333403L, 288597806669760892L, 91430288197103L },
            new long[] { 868836468420090470L, 127815921815005561L, 34413065578016L },
            new long[] { 487255036638784583L, 430487623791969842L, 23053081172816L },
            new long[] { 124462181441773470L, 902810424020138335L, 11487696932154L },
            new long[] { 225225512486764533L, 259666498587618221L, 63783299490636L },
            new long[] { 959008952310058822L, 544312419572409913L, 67720186971698L },
            new long[] { 481641953868218774L, 520781532296796249L, 95548255300263L },
            new long[] { 867697064507995236L, 723110424803456124L, 76085327132285L },
            new long[] { 205024910326572967L, 291684276865538926L, 37774242535411L },
            new long[] { 463092207058596522L, 675285653248258265L, 23701913275725L },
            new long[] { 994889534765745501L, 331913126375147341L, 29798860272258L },
            new long[] { 713721403798879715L, 288984856827726077L, 18495701454879L },
            new long[] { 513491373226651381L, 473527721580348144L, 38298203783031L },
            new long[] { 027392251122869539L, 918180278916522431L, 34829543829199L },
            new long[] { 654939159879593635L, 232632538044100059L, 40957953066405L },
            new long[] { 693803580388584903L, 371307642255121183L, 29746152185502L },
            new long[] { 689157993532961922L, 977186158236678424L, 41698116222072L },
            new long[] { 102390895523597457L, 269043877107275048L, 62467957194401L },
            new long[] { 979530901129967519L, 915061505504953922L, 23189706772547L },
            new long[] { 829009407770775672L, 314529584099251203L, 86188088225875L },
            new long[] { 340845647058077308L, 724483816533873502L, 11306739708304L },
            new long[] { 875491310547126581L, 363198008187129011L, 82959174767140L },
            new long[] { 366572897563400500L, 386269515456334926L, 97623331044818L },
            new long[] { 145521227251250327L, 070527831839425882L, 42846280183517L },
            new long[] { 652751691296897789L, 200581762165212827L, 55121603546981L },
            new long[] { 945765883352399886L, 339946437501907836L, 32238195734329L },
            new long[] { 091527357929701337L, 775180738168837861L, 75506164965184L },
            new long[] { 044983993173312731L, 623401942399639168L, 62177842752192L },
            new long[] { 660915035914677504L, 349566916674687634L, 32924185707147L },
            new long[] { 325116913619626622L, 219628894890102423L, 99518671430235L },
            new long[] { 535206946944540724L, 547471830798392868L, 73267460800591L },
            new long[] { 273348055556214818L, 417161514036427982L, 76841822524674L },
            new long[] { 422179826088076852L, 598647204516893989L, 97142617910342L },
            new long[] { 363333018982642090L, 346313767754307809L, 87783646182799L },
            new long[] { 543223812876952786L, 670883215120185883L, 10848802521674L },
            new long[] { 310363619763878039L, 464538636993009049L, 71329612474782L },
            new long[] { 339651327408011116L, 794223406235393808L, 62184073572399L },
            new long[] { 230030984490851411L, 087797941876876144L, 66627891981488L },
            new long[] { 335110989069790714L, 836764744779239180L, 60661826293682L },
            new long[] { 083659976645795096L, 990653640447425576L, 85786944089552L },
            new long[] { 047599490197230297L, 389607120198219976L, 66024396409905L },
            new long[] { 903785566085089252L, 973156037120041377L, 64913982680032L },
            new long[] { 539413042652315011L, 750275468906903707L, 16730939319872L },
            new long[] { 863754710598436791L, 795150954100921645L, 94809377245048L },
            new long[] { 969777599028300699L, 492431995700641917L, 78639167021187L },
            new long[] { 278410754449733078L, 614952811305876380L, 15368713711936L },
            new long[] { 033685442488917353L, 562561142322423255L, 40789923115535L },
            new long[] { 672322193204149535L, 648020369068063960L, 44889911501440L },
            new long[] { 977710650566631954L, 536053299340368006L, 41503128880339L },
            new long[] { 581403627822703280L, 146739058568557934L, 81234880673210L },
            new long[] { 525094512325230608L, 327592232845941706L, 82616570773948L },
            new long[] { 072429661980811197L, 319719839450180888L, 22918802058777L },
            new long[] { 882778948721859617L, 545090413245809786L, 77158542502016L },
            new long[] { 257473692284509516L, 186155435662884062L, 72107838435069L },
            new long[] { 555245252804609722L, 001723930671666823L, 20849603980134L },
            new long[] { 789781264330331690L, 524250874054075591L, 53503534226472L }
        };

        protected override long SolutionImplementation()
        {
            var sum = NUMBERS.Aggregate(Add);
            var high_digits = sum[2];
            while (high_digits / 10000000000L > 0) high_digits /= 10;
            return high_digits;
        }

        private long[] Add(long[] lhs, long[] rhs)
        {
            var result = new long[3];
            result[0] = lhs[0] + rhs[0];
            long carry = result[0] / CARRY;
            result[0] %= CARRY;
            result[1] = lhs[1] + rhs[1] + carry;
            carry = result[1] / CARRY;
            result[1] %= CARRY;
            result[2] = lhs[2] + rhs[2] + carry;

            return result;
        }
    }
}

