using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowPositionSaver;

namespace DesktopBibleVerse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Verse> lv = new List<Verse>();

        public MainWindow()
        {
            InitializeComponent();
            WPS.WPS_Window_Constructor(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WPS.WPS_Window_Loaded(this);

            string text = @"Iz 44:6: Toto praví Hospodin, král Izraele a jeho vykupitel, Hospodin zástupů: Já jsem první a já jsem poslední; kromě mne není žádný Bůh. 
Iz 43:11,15: Já, já jsem Hospodin a kromě mne žádný zachránce není. … Já jsem Hospodin, váš Svatý, stvořitel Izraele, váš král. 
Iz 44:24: Toto praví Hospodin, tvůj vykupitel, a ten, který tě utvářel od lůna matky: Já jsem Hospodin, který činím všechno: Já sám roztahuji nebesa, kdo byl se mnou, když jsem rozprostíral zemi? 
J 8:12: Ježíš k nim opět promluvil: Já jsem světlo světa. Kdo mne následuje, nebude chodit ve tmě, ale bude mít světlo života. 
J 14:6: Ježíš mu řekl: Já jsem ta Cesta, Pravda i Život. Nikdo nepřichází k Otci než skrze mne. 
Iz 42:16: Povedu slepé cestou, kterou neznali, dám jim kráčet stezkami, které neznali. Temnotu před nimi proměním ve světlo a hrbolatá místa v rovinu. Toto jsou věci, které učiním a kterých nezanechám. 
1Tm 2:5-6: Je totiž jeden Bůh, jeden je také prostředník mezi Bohem a lidmi, člověk Kristus Ježíš, který dal sám sebe jako výkupné za všechny, jako svědectví ve svůj čas. 
Mt 16:24: Tehdy Ježíš řekl svým učedníkům: Chce-li kdo jít za mnou, ať zapře sám sebe, vezme svůj kříž a následuje mne. 
Mt 16:25: Neboť kdo by chtěl svou duši zachránit, zahubí ji; kdo by však svou duši zahubil kvůli mně, nalezne ji. 
Př 14:12: Některá cesta připadá člověku správná, avšak nakonec je cestou smrti. 
Ko 3:2-4: Myslete na to, co je nahoře, ne na to, co je na zemi. Neboť jste zemřeli a váš život je ukryt s Kristem v Bohu. A když se ukáže Kristus, váš život, tehdy i vy se s ním ukážete ve slávě. 
Mt 6:33: Hledejte však nejprve Boží království a jeho spravedlnost, a to všechno vám bude přidáno. 
J 3:3,5: Ježíš mu odpověděl: Amen, amen, pravím tobě, nenarodí-li se kdo znovu, nemůže spatřit Boží království. … Ježíš odpověděl: Amen, amen, pravím tobě, nenarodí-li se kdo z vody a Ducha, nemůže vstoupit do Božího království. 
Sk 2:4: Všichni byli naplněni Duchem Svatým a začali mluvit jinými jazyky, jak jim Duch dával promlouvat. 
Ju 1:20-21: Vy však, milovaní, budujte se ve své nejsvětější víře, modlete se v Duchu Svatém, zachovejte se v Boží lásce a očekávejte milosrdenství našeho Pána Ježíše Krista k věčnému životu. 
1K 14:18: Děkuji Bohu, že mluvím jazyky více než vy všichni; 
Ř 8:5: Ti, kdo jsou živi podle těla, mají na mysli věci těla; ale ti, kdo jsou živi podle Ducha, myslí na věci Ducha. 
Ř 8:6: Myšlení těla znamená smrt, myšlení Ducha život a pokoj. 
1J 2:17: A svět pomíjí i jeho žádost; kdo však činí vůli Boží, zůstává na věčnost. 
Ga 6:9: V činění dobra neochabujme; nezemdlíme-li, budeme ve svůj čas žnout. 
1J 2:15: Nemilujte svět ani to, co je ve světě. Jestliže někdo miluje svět, není v něm Otcova láska. 
Mt 6:24: Nikdo nemůže být otrokem dvou pánů; buď bude totiž jednoho nenávidět a druhého milovat, nebo se k jednomu upne a druhým pohrdne. Nemůžete sloužit Bohu i mamonu. 
L 9:62: Ježíš mu řekl: Nikdo, kdo vloží svou ruku na pluh a ohlíží se zpět, není způsobilý pro Boží království. 
Ga 5:24: Ti, kdo patří Kristu Ježíši, ukřižovali tělo s jeho vášněmi a žádostmi. 
Žd 12:14: Usilujte o pokoj se všemi a o posvěcení, bez něhož nikdo neuvidí Pána. 
Ř 12:1: Vybízím vás tedy, bratři, skrze milosrdenství Boží, abyste vydali svá těla v oběť živou, svatou a příjemnou Bohu; to je vaše rozumná služba Bohu. 
1K 9:27: ale zasazuji dobře mířené rány svému tělu a podrobuji je, abych se snad – jiným hlásaje – sám nestal tím, kdo se neosvědčil. 
2P 3:11-12: Když se toto všechno takto rozplyne, jací musíte být ve svatém způsobu života a zbožnosti vy , kteří očekáváte a urychlujete příchod Božího dne! Kvůli němu se nebesa rozplynou v ohni a prvky se žárem roztaví. 
Dt 6:4-5: Slyš, Izraeli, Hospodin je náš Bůh, Hospodin jediný. Miluj Hospodina, svého Boha, celým svým srdcem, celou svou duší a celou svou silou. 
J 12:25: Kdo má rád svou duši, hubí ji; kdo nenávidí svou duši v tomto světě, uchrání ji k životu věčnému. 
1Te 5:19-22: Ducha neuhašujte. Proroctvími nepohrdejte. Všechno však zkoušejte; co je dobré, to pevně držte, a všeho, co vypadá zle, se vystříhejte. 
1K 6:12: Všechno mohu, ale ne všechno je užitečné; všechno mohu, ale ničím se nedám ovládnout. 
Jr 6:16: Toto praví Hospodin: Zastavte se na cestách a rozhlížejte se! Ptejte se na dávné stezky: Kde je ta dobrá cesta? Jděte po ní a najděte místo odpočinutí pro své duše. Říkají však: Nepůjdeme. 
Ž 119:133: Mé kroky upevni svými výroky, aby mě neovládla žádná nepravost. 
Dt 8:3: Pokořil tě, nechal tě hladovět, a pak tě krmil manou, kterou jsi neznal a kterou neznali tvoji otcové, aby tě přivedl k poznání, že člověk nežije jenom chlebem, ale že člověk žije vším, co vychází z Hospodinových úst. 
2Tm 3:15: od dětství přece znáš svatá Písma, jež ti mohou dát moudrost k záchraně skrze víru, která je v Kristu Ježíši. 
Př 13:1: Moudrý syn přijímá otcovo naučení, ale posměvač neposlouchá napomenutí. 
Př 23:24: Velmi bude jásat otec spravedlivého, rodič moudrého se z něj bude radovat. 
Př 22:28: Neposouvej dávné mezníky, které postavili tvoji otcové. 
Př 23:23: Kup si pravdu a neprodávej ji, moudrost, naučení a rozumnost. 
Př 4:7: Počátek moudrosti je: Získej moudrost! Za všechno své vlastnictví získej rozumnost. 
Mt 22:29: Ježíš jim odpověděl: Bloudíte, protože neznáte Písma ani Boží moc. 
Mt 7:15: Mějte se na pozoru před falešnými proroky, kteří k vám přicházejí v rouchu ovčím, ale uvnitř jsou draví vlci. 
Dt 4:31: Vždyť Hospodin, tvůj Bůh, je Bůh soucitný, neopustí tě a nezničí tě, nezapomene na smlouvu s tvými otci, kterou jim odpřisáhl. 
2K 7:1: Když tedy máme tato zaslíbení, milovaní, očisťme se od každé poskvrny těla i ducha, dokonávajíce své posvěcení v bázni Boží. 
J 9:4: Musím konat skutky toho, kdo mne poslal, dokud je den; přichází noc, kdy nikdo nebude moci pracovat. 
L 2:49: A on jim řekl: Jak to, že jste mne hledali? Nevěděli jste, že musím být ve věcech svého Otce?
L 4:43: On jim však řekl: Také ostatním městům musím zvěstovat evangelium Božího království, neboť k tomu jsem byl poslán. 
Ř 10:17: Víra je tedy ze slyšení zvěsti a zvěst skrze slovo Kristovo. 
L 24:25: A on jim řekl: Ó nerozumní a zpozdilého srdce, abyste věřili tomu všemu, co mluvili proroci! 
Př 4:18: Stezka spravedlivých je jako záře úsvitu, září víc a víc, až do bílého dne. 
J 6:63: Duch je ten, který obživuje, tělo nic neznamená. Slova, která jsem vám pověděl já, jsou duch a jsou život. 
Ga 6:7-8: Nemylte se, Bohu se nikdo nebude vysmívat. Co člověk zaseje, to také sklidí. Kdo zasévá pro své tělo, z těla sklidí zkázu; kdo zasévá pro Ducha, z Ducha sklidí život věčný. 
1K 10:13: Nezachvátilo vás jiné pokušení než lidské; věrný je však Bůh, který vás nenechá zkusit více, než snesete, ale se zkouškou dá i východisko, abyste ji mohli snést. 
Ž 33:12: Blahoslavený je národ, jehož Bohem je Hospodin; lid, který si vyvolil za dědictví. 
Př 14:34: Spravedlnost vyvýší národ, ale hřích je hanbou národů. 
Ž 9:18: Ničemové se vrátí do podsvětí – všechny národy zapomínající na Boha. 
Př 3:5-6: Důvěřuj Hospodinu celým svým srdcem, nespoléhej se na svoji rozumnost. Poznávej ho na všech svých cestách, a on napřímí tvé stezky. 
Ef 5:22-23: Ženy, podřizujte se svým mužům jako Pánu, neboť muž je hlavou ženy, jako je Kristus hlavou církve; on je zachráncem těla. 
1Tm 6:9: Ti, kdo chtějí být bohatí, upadají do pokušení a do léčky a do mnoha nerozumných a škodlivých žádostí, které je vtahují do zkázy a záhuby. 
Žd 10:25: Nezanedbávejme své společné shromažďování, jak mají někteří ve zvyku, nýbrž povzbuzujme se, a to tím více, čím více vidíte, že se ten den přibližuje. 
2Te 3:6: Přikazujeme vám, bratři, ve jménu našeho Pána Ježíše Krista, abyste se stranili každého bratra, který žije neukázněně, a ne podle toho, co jste od nás převzali. 
Ř 12:9-10: Láska ať je bez přetvářky. Ošklivte si zlo, lněte k dobrému. Vroucně se navzájem milujte bratrskou láskou, v prokazování úcty předcházejte jeden druhého. 
Ef 5:11: a nemějte žádnou účast na neplodných skutcích tmy, spíše je usvědčujte. 
1J 3:2: Milovaní, nyní jsme děti Boží; a ještě se neukázalo, co budeme. Víme však, že až se zjeví, budeme mu podobni, protože ho uvidíme takového, jaký je. 
L 6:26: Běda, když o vás budou všichni lidé mluvit dobře; vždyť totéž činili jejich otcové falešným prorokům. 
J 15:19: Kdybyste byli ze světa, svět by miloval to, co je jeho. Že však nejste ze světa, ale já jsem si vás ze světa vybral, proto vás svět nenávidí. 
Ř 12:2: A nepřipodobňujte se tomuto věku, nýbrž proměňujte se obnovou své mysli, abyste mohli zkoumat, co je Boží vůle, co je dobré, přijatelné a dokonalé. 
1P 1:14-15: Jako poslušné děti se nepřizpůsobujte dřívějším žádostem, jako když jste byli v nevědomosti, ale podle toho Svatého, který vás povolal, se i vy staňte svatými v celém svém způsobu života. 
1K 6:20: Byli jste přece koupeni za velikou cenu; oslavte tedy svým tělem Boha. 
Př 11:4: Majetek neprospěje v den hněvu, ale spravedlnost vysvobodí od smrti. 
1Te 4:4: aby každý z vás uměl zacházet se svou nádobou ve svatosti a úctě,
L 14:27: Kdo jde za mnou a nenese svůj kříž, nemůže být mým učedníkem. 
L 14:33: Tak tedy žádný z vás, kdo neopouští všechno, co mu náleží, nemůže být mým učedníkem. 
Žd 10:38: můj spravedlivý bude žít z víry, ale kdyby ustoupil, nebude v něm mít moje duše zalíbení. 
Jk 4:4: Cizoložníci a cizoložnice! Nevíte, že přátelství se světem je nepřátelství s Bohem? Kdo tedy chce být přítelem světa, stává se nepřítelem Božím. 
Kaz 8:11: Když není rozsudek nad zlým činem vykonán rychle, srdce lidských synů se díky tomu nadme, takže páchají zlo. 
2K 13:5: Sami sebe zkoušejte, jste-li ve víře, sami sebe zkoumejte. 
Ž 7:11: Svůj štít mám v Bohu, jenž zachraňuje lidi přímého srdce. 
Zj 2:5: Rozpomeň se, odkud jsi spadl, učiň pokání a začni jednat jako dřív ! Ne-li, přijdu k tobě brzy a pohnu tvým svícnem z jeho místa; jestliže neučiníš pokání. 
1K 12:8-10: Neboť jednomu je skrze Ducha dáváno slovo moudrosti, jinému podle téhož Ducha slovo poznání; dalšímu víra v témž Duchu, jinému dary uzdravování v témž Duchu; jinému působení mocných činů, jinému proroctví, jinému rozlišování duchů, dalšímu druhy jazyků, jinému pak výklad jazyků. 
Mt 24:11-13: Také povstanou mnozí lživí proroci a mnohé svedou. A protože vzroste bezzákonnost, ochladne láska mnohých. Ten však, kdo vytrvá do konce, bude zachráněn. 
Ko 2:8: Dávejte si pozor, ať vás někdo neodvede jako zajatce skrze filozofii – prázdný svod podle lidské tradice, podle živlů světa, a ne podle Krista. 
1Te 2:4: ale Bůh nás vyzkoušel, aby nám svěřil evangelium, proto mluvíme ne tak, jako bychom se chtěli zalíbit lidem, ale tak, abychom se zalíbili Bohu, který zkouší naše srdce. 
Ef 5:17-18: Proto nebuďte nerozumní, ale rozumějte, co je Pánova vůle. A neopíjejte se vínem, v němž je prostopášnost, ale naplňujte se Duchem,
Mt 3:11: Já vás křtím ve vodě k pokání; ale ten, který přichází za mnou, je silnější než já; jemu nejsem hoden ani nést sandály. On vás bude křtít v Duchu Svatém a ohni. 
Sk 2:38 B21: Čiňte pokání, odpověděl Petr, a každý se nechte pokřtít ve jménu Ježíše Krista, aby vám byly odpuštěny hříchy. I vy přijmete dar Ducha svatého,
J 14:8-9: Filip mu řekl: Pane, ukaž nám Otce a to nám stačí. Ježíš mu řekl: Tak dlouho jsem s vámi, Filipe, a ty jsi mne nepoznal? Kdo viděl mne, viděl Otce. Jak můžeš říkat: ‚Ukaž nám Otce‘?
Zj 1:7: ‚Hle, přichází s oblaky‘ a ‚uzří jej každé oko, i ti, kteří jej probodli‘, a ‚budou se pro něho bít v prsa všechny kmeny země‘. Ano, amen. 
Žd 10:36-37: Je vám totiž třeba vytrvalosti, abyste vykonali Boží vůli a obdrželi zaslíbení. ‚Neboť ještě velmi, velmi krátký čas, a ten, který má přijít, přijde a nebude otálet; 
Iz 42:13: Hospodin vyjde jako hrdina, jako bojovník vzbudí svou horlivost. Rozkřikne se, ano, spustí válečný pokřik, ukáže převahu nad svými nepřáteli. 
1Te 5:23: A sám Bůh pokoje kéž vás celé posvětí a celého vašeho ducha i duši i tělo kéž zachová bez poskvrny až k příchodu našeho Pána Ježíše Krista. 
1K 10:33: stejně jako i já se chci všem ve všem líbit a nehledám svůj prospěch, nýbrž prospěch mnohých, aby byli zachráněni. 
Mal 3:10: Přineste celý desátek do skladu, ať je potrava v mém domě. Vyzkoušejte mě takto, praví Hospodin zástupů, zdali vám neotevřu nebeské průduchy a ne vyleji na vás požehnání, dokud ne bude dostatek. 
Zj 7:12: Amen! Dobrořečení a sláva, moudrost i vděčnost, úcta a moc i síla náleží našemu Bohu na věky věků. Amen. 
Zj 20:4: A spatřil jsem trůny a ty, kteří se na ně posadili, a byl jim svěřen soud; uviděl jsem také duše těch, kteří byli sťati pro Ježíšovo svědectví a pro Boží slovo, i ty, kteří se nepoklonili šelmě ani jejímu obrazu a nepřijali její cejch na čelo ani na ruku. I ožili a kralovali s Kristem tisíc let. 
Zj 20:5-6: Ostatní mrtví neožili, dokud se těch tisíc let nedovršilo. To je první vzkříšení. Blahoslavený a svatý, kdo má podíl na prvním vzkříšení; nad těmi druhá smrt nemá pravomoc, nýbrž budou kněžími Božími a Kristovými a budou s ním kralovat tisíc let. 
1Te 4:16-17: protože za zvuku přikazujícího zvolání, hlasu archanděla a Boží polnice sám Pán sestoupí z nebe a mrtví v Kristu vstanou nejdříve. Potom my živí, kteří tu budeme ponecháni, budeme spolu s nimi uchváceni v oblacích do vzduchu k setkání s Pánem. A tak už na vždy budeme s Pánem. 
Mt 24:21: Neboť tehdy bude velké soužení, jaké nenastalo od počátku světa až do nynějška, a nikdy již nenastane. 
Mt 24:29: Ihned po soužení oněch dnů se zatmí slunce a měsíc nebude vydávat svou zář, hvězdy budou padat z nebe a mocnosti nebes se zatřesou. 
Mt 24:30: Potom se ukáže znamení Syna člověka na nebi, a tehdy se budou bít v prsa všechny kmeny země. A uvidí Syna člověka přicházejícího na nebeských oblacích s mocí a velikou slávou. 
Mt 24:31: A pošle své anděly s mohutným zvukem polnice a ti shromáždí jeho vyvolené ze čtyř větrů, od jednoho nejzazšího konce nebes až k jejich druhému nejzazšímu konci. 
1K 15:51-52: Hle, říkám vám tajemství: Ne všichni zemřeme, ale všichni budeme proměněni, naráz, v okamžiku, při zvuku poslední polnice. Zazní polnice, a mrtví vstanou jako neporušitelní a my budeme proměněni. 
Ef 4:11-13: A on dal jedny apoštoly, jiné proroky, některé evangelisty, jiné pastýře a učitele, aby připravili svaté k dílu služby, k vybudování těla Kristova, dokud nedospějeme všichni k jednotě víry a plného poznání Syna Božího, v dospělého muže, v míru postavy Kristovy plnosti,
Zj 12:11: Oni nad ním zvítězili pro krev Beránkovu a pro slovo svého svědectví; a nemilovali svou duši až na smrt. 
2Tm 3:12: Všichni, kdo chtějí zbožně žít v Kristu Ježíši, budou pronásledováni. 
Zj 6:9: A když otevřel pátou pečeť, spatřil jsem pod oltářem duše zabitých pro Boží slovo a pro svědectví, které věrně drželi. 
Zj 22:7: A hle, přijdu brzy. Blahoslavený, kdo zachovává slova proroctví tohoto svitku. 
Zj 22:13: Já jsem Alfa i Omega, první i poslední, počátek i konec. 
Zj 22:17: A Duch i Nevěsta praví: Přijď. A kdo slyší, ať řekne: Přijď. A kdo žízní, ať přijde, a kdo chce, ať si zdarma vezme vodu života. 
Zj 22:18-19: Já dosvědčuji každému, kdo slyší slova proroctví tohoto svitku: kdo by k nim něco přidal, tomu Bůh přidá ran zapsaných v tomto svitku; a kdo by ze slov svitku tohoto proroctví něco odejmul, tomu Bůh odejme jeho díl ze stromu života a ze svatého města, které byly popsány v tomto svitku. "; 
  lv = GH.ReadVerses(text);

            LoadSettings();

            this.LocationChanged += Window_LocationChanged;
            this.Width = 1000;//zrušit WPS width     

            origL = Left;
            origT = Top;

            loaded = true;
        }

        bool loaded = false;

        public void LoadSettings()
        {
            string color = Properties.Settings.Default.Background;
            string alpha = Properties.Settings.Default.Alpha;
            string fontcolor = Properties.Settings.Default.FontColor;
            bbb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + alpha + color));
            bbb.MaxWidth = Properties.Settings.Default.MaxWidth;
            lblVerse.FontSize = Properties.Settings.Default.FontSizeVerse;
            lblRef.FontSize = Properties.Settings.Default.FontSizeRef;
            SolidColorBrush b = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + fontcolor));
            lblVerse.Foreground = b;
            lblRef.Foreground = b;
            lblVerse.FontFamily = new FontFamily(Properties.Settings.Default.Font);
            lblRef.FontFamily = new FontFamily(Properties.Settings.Default.Font);
            VerseSet(Properties.Settings.Default.VerseIndex);
        }

        public void SaveSettings()
        {
            if (!loaded)
                return;
            SolidColorBrush b = (SolidColorBrush)bbb.Background;
            string color = BitConverter.ToString(new byte[] { b.Color.R, b.Color.G, b.Color.B }).Replace("-", "");
            string alpha = BitConverter.ToString(new byte[] { b.Color.A });
            SolidColorBrush b2 = (SolidColorBrush)lblVerse.Foreground;
            string fontcolor = BitConverter.ToString(new byte[] { b2.Color.R, b2.Color.G, b2.Color.B }).Replace("-", "");

            Properties.Settings.Default.Font = lblVerse.FontFamily.FamilyNames.ElementAt(0).Value;
            Properties.Settings.Default.Background = color;
            Properties.Settings.Default.Alpha = alpha;
            Properties.Settings.Default.MaxWidth = bbb.MaxWidth;
            Properties.Settings.Default.FontSizeVerse = lblVerse.FontSize;
            Properties.Settings.Default.FontSizeRef = lblRef.FontSize;
            Properties.Settings.Default.FontColor = fontcolor;
            Properties.Settings.Default.VerseIndex = index;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
            WPS.WPS_Window_Closing(this);
        }

        double origL;
        double origT;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            DragMove();
            origL = Left;
            origT = Top;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;
            if (origL == Left && origT == Top)
                VersePlus();
        }

        int index;

        void VerseSet(int index)
        {
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            this.index = index;
            SaveSettings();
        }

        void VersePlus()
        {
            index++;
            if (index >= lv.Count)
                index = 0;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        void VerseMinus()
        {
            index--;
            if (index < 0)
                index = lv.Count - 1;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        void VerseRandom()
        {
            int old_index = index;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                index = r.Next(0, lv.Count);
                if (index != old_index)
                    break;
            }
            
            if (index < 0)
                index = 0;
            if (index >= lv.Count)
                index = lv.Count - 1;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        private void MiNext_Click(object sender, RoutedEventArgs e)
        {
            VersePlus();
        }

        private void MiPrevious_Click(object sender, RoutedEventArgs e)
        {
            VerseMinus();
        }

        private void MiRandom_Click(object sender, RoutedEventArgs e)
        {
            VerseRandom();
        }

        private void MiSetup_Click(object sender, RoutedEventArgs e)
        {
            winSettings ws = new winSettings(this);
            ws.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                lblVerse.MaxWidth = 400;
        }

        private void MiClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
                this.WindowState = WindowState.Normal;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch
            {

            }
        }
    }
}
