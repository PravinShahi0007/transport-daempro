using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class MyUsers
    {
    }

    [Serializable]
    public class MyEncryption
    {

        public static string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static string base64Decode(string sData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }

    [Serializable]
    public class TblRoles
    {
        public string RoleName { get; set; }
        public string PassType { get; set; }
        public string UserName { get; set; }
        public string UserOp { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<bool> Pass10  { get; set; }
	    public System.Nullable<bool> Pass101  { get; set; }
	    public System.Nullable<bool> Pass102  { get; set; }
	    public System.Nullable<bool> Pass103  { get; set; }
	    public System.Nullable<bool> Pass104  { get; set; }
	    public System.Nullable<bool> Pass11  { get; set; } 
	    public System.Nullable<bool> Pass111  { get; set; }
	    public System.Nullable<bool> Pass112  { get; set; }
	    public System.Nullable<bool> Pass113  { get; set; }
	    public System.Nullable<bool> Pass114  { get; set; }
	    public System.Nullable<bool> Pass12  { get; set; }
	    public System.Nullable<bool> Pass121  { get; set; }
	    public System.Nullable<bool> Pass122  { get; set; }
	    public System.Nullable<bool> Pass123  { get; set; }
	    public System.Nullable<bool> Pass124  { get; set; }
	    public System.Nullable<bool> Pass13  { get; set; }
	    public System.Nullable<bool> Pass131  { get; set; }
	    public System.Nullable<bool> Pass132  { get; set; }
	    public System.Nullable<bool> Pass133  { get; set; }
	    public System.Nullable<bool> Pass134  { get; set; }
	    public System.Nullable<bool> Pass14   { get; set; }
	    public System.Nullable<bool> Pass141  { get; set; }
	    public System.Nullable<bool> Pass142  { get; set; }
	    public System.Nullable<bool> Pass143  { get; set; }
	    public System.Nullable<bool> Pass144  { get; set; }
	    public System.Nullable<bool> Pass15   { get; set; }
	    public System.Nullable<bool> Pass151  { get; set; }
	    public System.Nullable<bool> Pass152  { get; set; }
	    public System.Nullable<bool> Pass153  { get; set; }
	    public System.Nullable<bool> Pass154  { get; set; }
	    public System.Nullable<bool> Pass16   { get; set; }
	    public System.Nullable<bool> Pass161  { get; set; }
	    public System.Nullable<bool> Pass162  { get; set; }
	    public System.Nullable<bool> Pass163  { get; set; }
	    public System.Nullable<bool> Pass164  { get; set; }
	    public System.Nullable<bool> Pass17   { get; set; }
	    public System.Nullable<bool> Pass171  { get; set; }
	    public System.Nullable<bool> Pass172  { get; set; }
	    public System.Nullable<bool> Pass173  { get; set; }
	    public System.Nullable<bool> Pass174  { get; set; }
	    public System.Nullable<bool> Pass18   { get; set; }
	    public System.Nullable<bool> Pass181  { get; set; }
	    public System.Nullable<bool> Pass182  { get; set; }
	    public System.Nullable<bool> Pass183  { get; set; }
	    public System.Nullable<bool> Pass184  { get; set; }
	    public System.Nullable<bool> Pass19   { get; set; }
	    public System.Nullable<bool> Pass191  { get; set; }
	    public System.Nullable<bool> Pass192  { get; set; }
	    public System.Nullable<bool> Pass193  { get; set; }
	    public System.Nullable<bool> Pass194  { get; set; }
	    public System.Nullable<bool> Pass20   { get; set; }
	    public System.Nullable<bool> Pass201  { get; set; }
	    public System.Nullable<bool> Pass202  { get; set; }
	    public System.Nullable<bool> Pass203  { get; set; }
	    public System.Nullable<bool> Pass204  { get; set; }
	    public System.Nullable<bool> Pass205  { get; set; }
        public System.Nullable<bool> Pass206  { get; set; }
	    public System.Nullable<bool> Pass21   { get; set; }
	    public System.Nullable<bool> Pass211  { get; set; }
	    public System.Nullable<bool> Pass212  { get; set; }
	    public System.Nullable<bool> Pass213  { get; set; }
	    public System.Nullable<bool> Pass214  { get; set; }
	    public System.Nullable<bool> Pass215  { get; set; }
        public System.Nullable<bool> Pass216  { get; set; }
	    public System.Nullable<bool> Pass22   { get; set; }
	    public System.Nullable<bool> Pass221  { get; set; }
	    public System.Nullable<bool> Pass222  { get; set; }
	    public System.Nullable<bool> Pass223  { get; set; }
	    public System.Nullable<bool> Pass224  { get; set; }
	    public System.Nullable<bool> Pass225  { get; set; }
        public System.Nullable<bool> Pass226  { get; set; }
	    public System.Nullable<bool> Pass23   { get; set; }
	    public System.Nullable<bool> Pass231  { get; set; }
	    public System.Nullable<bool> Pass232  { get; set; }
	    public System.Nullable<bool> Pass233  { get; set; }
	    public System.Nullable<bool> Pass234  { get; set; }
	    public System.Nullable<bool> Pass235  { get; set; }
        public System.Nullable<bool> Pass236  { get; set; }
	    public System.Nullable<bool> Pass24   { get; set; }
	    public System.Nullable<bool> Pass241  { get; set; }
	    public System.Nullable<bool> Pass242  { get; set; }
	    public System.Nullable<bool> Pass243  { get; set; }
	    public System.Nullable<bool> Pass244  { get; set; }
	    public System.Nullable<bool> Pass245  { get; set; }
	    public System.Nullable<bool> Pass25   { get; set; }
	    public System.Nullable<bool> Pass251  { get; set; }
	    public System.Nullable<bool> Pass252  { get; set; }
	    public System.Nullable<bool> Pass253  { get; set; }
	    public System.Nullable<bool> Pass254  { get; set; }
	    public System.Nullable<bool> Pass255  { get; set; }
	    public System.Nullable<bool> Pass26   { get; set; }
	    public System.Nullable<bool> Pass261  { get; set; }
	    public System.Nullable<bool> Pass262  { get; set; }
	    public System.Nullable<bool> Pass263  { get; set; }
	    public System.Nullable<bool> Pass264  { get; set; }
	    public System.Nullable<bool> Pass265  { get; set; }
	    public System.Nullable<bool> Pass27   { get; set; }
	    public System.Nullable<bool> Pass271  { get; set; }
	    public System.Nullable<bool> Pass272  { get; set; }
	    public System.Nullable<bool> Pass273  { get; set; }
	    public System.Nullable<bool> Pass274  { get; set; }
	    public System.Nullable<bool> Pass275  { get; set; }
	    public System.Nullable<bool> Pass28  { get; set; }
	    public System.Nullable<bool> Pass281  { get; set; }
	    public System.Nullable<bool> Pass282  { get; set; }
	    public System.Nullable<bool> Pass283  { get; set; }
	    public System.Nullable<bool> Pass284  { get; set; }
	    public System.Nullable<bool> Pass285  { get; set; }
	    public System.Nullable<bool> Pass29  { get; set; }
	    public System.Nullable<bool> Pass291  { get; set; }
	    public System.Nullable<bool> Pass292  { get; set; }
	    public System.Nullable<bool> Pass293  { get; set; }
	    public System.Nullable<bool> Pass294  { get; set; }
	    public System.Nullable<bool> Pass295  { get; set; }
	    public System.Nullable<bool> Pass30  { get; set; }
	    public System.Nullable<bool> Pass301  { get; set; }
	    public System.Nullable<bool> Pass302  { get; set; }
	    public System.Nullable<bool> Pass303  { get; set; }
	    public System.Nullable<bool> Pass304  { get; set; }
	    public System.Nullable<bool> Pass305  { get; set; }
	    public System.Nullable<bool> Pass31  { get; set; }
	    public System.Nullable<bool> Pass311  { get; set; }
	    public System.Nullable<bool> Pass312  { get; set; }
	    public System.Nullable<bool> Pass313  { get; set; }
	    public System.Nullable<bool> Pass314  { get; set; }
	    public System.Nullable<bool> Pass315  { get; set; }
	    public System.Nullable<bool> Pass32  { get; set; }
	    public System.Nullable<bool> Pass321  { get; set; }
	    public System.Nullable<bool> Pass322  { get; set; }
	    public System.Nullable<bool> Pass323  { get; set; }
	    public System.Nullable<bool> Pass324  { get; set; }
	    public System.Nullable<bool> Pass325  { get; set; }
	    public System.Nullable<bool> Pass33  { get; set; }
	    public System.Nullable<bool> Pass331  { get; set; }
	    public System.Nullable<bool> Pass332  { get; set; }
	    public System.Nullable<bool> Pass333  { get; set; }
	    public System.Nullable<bool> Pass334  { get; set; }
	    public System.Nullable<bool> Pass335  { get; set; }
	    public System.Nullable<bool> Pass34  { get; set; }
	    public System.Nullable<bool> Pass341  { get; set; }
	    public System.Nullable<bool> Pass342  { get; set; }
	    public System.Nullable<bool> Pass343  { get; set; }
	    public System.Nullable<bool> Pass344  { get; set; }
	    public System.Nullable<bool> Pass345  { get; set; }
	    public System.Nullable<bool> Pass35  { get; set; }
	    public System.Nullable<bool> Pass351  { get; set; }
	    public System.Nullable<bool> Pass352  { get; set; }
	    public System.Nullable<bool> Pass353  { get; set; }
	    public System.Nullable<bool> Pass354  { get; set; }
	    public System.Nullable<bool> Pass355  { get; set; }
	    public System.Nullable<bool> Pass36  { get; set; }
	    public System.Nullable<bool> Pass361  { get; set; }
	    public System.Nullable<bool> Pass362  { get; set; }
	    public System.Nullable<bool> Pass363  { get; set; }
	    public System.Nullable<bool> Pass364  { get; set; }
	    public System.Nullable<bool> Pass365  { get; set; }
	    public System.Nullable<bool> Pass37  { get; set; }
	    public System.Nullable<bool> Pass371  { get; set; }
	    public System.Nullable<bool> Pass372  { get; set; }
	    public System.Nullable<bool> Pass373  { get; set; }
	    public System.Nullable<bool> Pass374  { get; set; }
	    public System.Nullable<bool> Pass375  { get; set; }
	    public System.Nullable<bool> Pass38  { get; set; }
	    public System.Nullable<bool> Pass381  { get; set; }
	    public System.Nullable<bool> Pass382  { get; set; }
	    public System.Nullable<bool> Pass383  { get; set; }
	    public System.Nullable<bool> Pass384  { get; set; }
	    public System.Nullable<bool> Pass385  { get; set; }
	    public System.Nullable<bool> Pass39  { get; set; }
	    public System.Nullable<bool> Pass391  { get; set; }
	    public System.Nullable<bool> Pass392  { get; set; }
	    public System.Nullable<bool> Pass393  { get; set; }
	    public System.Nullable<bool> Pass394  { get; set; }
	    public System.Nullable<bool> Pass395  { get; set; }
	    public System.Nullable<bool> Pass40  { get; set; }
	    public System.Nullable<bool> Pass401  { get; set; }
	    public System.Nullable<bool> Pass402  { get; set; }
	    public System.Nullable<bool> Pass403  { get; set; }
	    public System.Nullable<bool> Pass404  { get; set; }
	    public System.Nullable<bool> Pass405  { get; set; }
	    public System.Nullable<bool> Pass41  { get; set; }
	    public System.Nullable<bool> Pass411  { get; set; }
	    public System.Nullable<bool> Pass412  { get; set; }
	    public System.Nullable<bool> Pass413  { get; set; }
	    public System.Nullable<bool> Pass414  { get; set; }
	    public System.Nullable<bool> Pass415  { get; set; }
        public System.Nullable<bool> Pass416 { get; set; }
	    public System.Nullable<bool> Pass42  { get; set; }
	    public System.Nullable<bool> Pass421  { get; set; }
	    public System.Nullable<bool> Pass422  { get; set; }
	    public System.Nullable<bool> Pass423  { get; set; }
	    public System.Nullable<bool> Pass424  { get; set; }
	    public System.Nullable<bool> Pass425  { get; set; }
	    public System.Nullable<bool> Pass43  { get; set; }
	    public System.Nullable<bool> Pass431  { get; set; }
	    public System.Nullable<bool> Pass432  { get; set; }
	    public System.Nullable<bool> Pass433  { get; set; }
	    public System.Nullable<bool> Pass434  { get; set; }
	    public System.Nullable<bool> Pass435  { get; set; }
	    public System.Nullable<bool> Pass44  { get; set; }
	    public System.Nullable<bool> Pass441  { get; set; }
	    public System.Nullable<bool> Pass442  { get; set; }
	    public System.Nullable<bool> Pass443  { get; set; }
	    public System.Nullable<bool> Pass444  { get; set; }
	    public System.Nullable<bool> Pass445  { get; set; }
	    public System.Nullable<bool> Pass45  { get; set; }
	    public System.Nullable<bool> Pass451  { get; set; }
	    public System.Nullable<bool> Pass452  { get; set; }
	    public System.Nullable<bool> Pass453  { get; set; }
	    public System.Nullable<bool> Pass454  { get; set; }
	    public System.Nullable<bool> Pass455  { get; set; }
	    public System.Nullable<bool> Pass46  { get; set; }
	    public System.Nullable<bool> Pass461  { get; set; }
	    public System.Nullable<bool> Pass462  { get; set; }
	    public System.Nullable<bool> Pass463  { get; set; }
	    public System.Nullable<bool> Pass464  { get; set; }
	    public System.Nullable<bool> Pass465  { get; set; }
	    public System.Nullable<bool> Pass47  { get; set; }
	    public System.Nullable<bool> Pass471  { get; set; }
	    public System.Nullable<bool> Pass472  { get; set; }	
        public System.Nullable<bool> Pass473  { get; set; }
	    public System.Nullable<bool> Pass474  { get; set; }
	    public System.Nullable<bool> Pass475  { get; set; }
	    public System.Nullable<bool> Pass48  { get; set; }
	    public System.Nullable<bool> Pass481  { get; set; }
        public System.Nullable<bool> Pass482 { get; set; }
	    public System.Nullable<bool> Pass483  { get; set; }
	    public System.Nullable<bool> Pass484  { get; set; }
	    public System.Nullable<bool> Pass485  { get; set; }
	    public System.Nullable<bool> Pass49  { get; set; }
	    public System.Nullable<bool> Pass491  { get; set; }
	    public System.Nullable<bool> Pass492  { get; set; }
	    public System.Nullable<bool> Pass493  { get; set; }
	    public System.Nullable<bool> Pass494  { get; set; }
	    public System.Nullable<bool> Pass495  { get; set; }
	    public System.Nullable<bool> Pass50  { get; set; }
	    public System.Nullable<bool> Pass501  { get; set; }
        public System.Nullable<bool> Pass502 { get; set; }
	    public System.Nullable<bool> Pass51  { get; set; }
	    public System.Nullable<bool> Pass52  { get; set; }
        public System.Nullable<bool> Pass521 { get; set; }
	    public System.Nullable<bool> Pass53  { get; set; }
	    public System.Nullable<bool> Pass54  { get; set; }
	    public System.Nullable<bool> Pass55  { get; set; }
	    public System.Nullable<bool> Pass56  { get; set; }
	    public System.Nullable<bool> Pass57  { get; set; }
	    public System.Nullable<bool> Pass58  { get; set; }
	    public System.Nullable<bool> Pass59  { get; set; }
	    public System.Nullable<bool> Pass60  { get; set; }
	    public System.Nullable<bool> Pass61  { get; set; }
	    public System.Nullable<bool> Pass62  { get; set; }
	    public System.Nullable<bool> Pass63  { get; set; }
	    public System.Nullable<bool> Pass64  { get; set; }
	    public System.Nullable<bool> Pass65  { get; set; }
	    public System.Nullable<bool> Pass66  { get; set; }
	    public System.Nullable<bool> Pass67  { get; set; }
	    public System.Nullable<bool> Pass68  { get; set; }
	    public System.Nullable<bool> Pass69  { get; set; }
	    public System.Nullable<bool> Pass70   { get; set; }
        public System.Nullable<bool> Pass01 { get; set; }
        public System.Nullable<bool> Pass011 { get; set; }
        public System.Nullable<bool> Pass012 { get; set; }
        public System.Nullable<bool> Pass013 { get; set; }
        public System.Nullable<bool> Pass014 { get; set; }
        public System.Nullable<bool> Pass015 { get; set; }
        public System.Nullable<bool> Pass1 { get; set; }
        public short? Interface { get; set; }

        public TblRoles()
        {
                this.RoleName = "";
                this.PassType = ""; 
                this.UserName = ""; 
                this.UserOp = ""; 
                this.UserDate = "";
	            this.Pass10= false;
	            this.Pass101= false;
	            this.Pass102= false;
	            this.Pass103= false;
	            this.Pass104= false;
	            this.Pass11 = false;
	            this.Pass111= false;
	            this.Pass112= false;
	            this.Pass113= false;
	            this.Pass114= false;
	            this.Pass12 = false;
	            this.Pass121= false;
	            this.Pass122= false;
	            this.Pass123= false;
	            this.Pass124= false;
	            this.Pass13 = false;
	            this.Pass131= false;
	            this.Pass132= false;
	            this.Pass133= false;
	            this.Pass134= false;
	            this.Pass14 = false;
	            this.Pass141= false;
	            this.Pass142= false;
	            this.Pass143= false;
	            this.Pass144= false;
	            this.Pass15 = false;
	            this.Pass151= false;
	            this.Pass152= false;
	            this.Pass153= false;
	            this.Pass154= false;
	            this.Pass16 = false;
	            this.Pass161= false;
	            this.Pass162= false;
	            this.Pass163= false;
	            this.Pass164= false;
	            this.Pass17 = false;
	            this.Pass171= false;
	            this.Pass172= false;
	            this.Pass173= false;
	            this.Pass174= false;
	            this.Pass18 = false;
	            this.Pass181= false;
	            this.Pass182= false;
	            this.Pass183= false;
	            this.Pass184= false;
	            this.Pass19 = false;
	            this.Pass191= false;
	            this.Pass192= false;
	            this.Pass193= false;
	            this.Pass194= false;
	            this.Pass20 = false;
	            this.Pass201= false;
	            this.Pass202= false;
	            this.Pass203= false;
	            this.Pass204= false;
	            this.Pass205= false;
                this.Pass206= false;
	            this.Pass21 = false;
	            this.Pass211= false;
	            this.Pass212= false;
	            this.Pass213= false;
	            this.Pass214= false;
	            this.Pass215= false;
                this.Pass216 = false;
	            this.Pass22 = false;
	            this.Pass221= false;
	            this.Pass222= false;
	            this.Pass223= false;
	            this.Pass224= false;
	            this.Pass225= false;
                this.Pass226 = false;
	            this.Pass23 = false;
	            this.Pass231= false;
	            this.Pass232= false;
	            this.Pass233= false;
	            this.Pass234= false;
	            this.Pass235= false;
                this.Pass236 = false;
	            this.Pass24 = false;
	            this.Pass241= false;
	            this.Pass242= false;
	            this.Pass243= false;
	            this.Pass244= false;
	            this.Pass245= false;
	            this.Pass25 = false;
	            this.Pass251= false;
	            this.Pass252= false;
	            this.Pass253= false;
	            this.Pass254= false;
	            this.Pass255= false;
	            this.Pass26 = false;
	            this.Pass261= false;
	            this.Pass262= false;
	            this.Pass263= false;
	            this.Pass264= false;
	            this.Pass265= false;
	            this.Pass27 = false;
	            this.Pass271= false;
	            this.Pass272= false;
	            this.Pass273= false;
	            this.Pass274= false;
	            this.Pass275= false;
	            this.Pass28= false;
	            this.Pass281= false;
	            this.Pass282= false;
	            this.Pass283= false;
	            this.Pass284= false;
	            this.Pass285= false;
	            this.Pass29= false;
	            this.Pass291= false;
	            this.Pass292= false;
	            this.Pass293= false;
	            this.Pass294= false;
	            this.Pass295= false;
	            this.Pass30= false;
	            this.Pass301= false;
	            this.Pass302= false;
	            this.Pass303= false;
	            this.Pass304= false;
	            this.Pass305= false;
	            this.Pass31= false;
	            this.Pass311= false;
	            this.Pass312= false;
	            this.Pass313= false;
	            this.Pass314= false;
	            this.Pass315= false;
                this.Pass32= false;
                this.Pass321= false;
                this.Pass322= false;
                this.Pass323= false;
                this.Pass324= false;
                this.Pass325= false;
                this.Pass33= false;
                this.Pass331= false;
                this.Pass332= false;
                this.Pass333= false;
                this.Pass334= false;
                this.Pass335= false;
                this.Pass34= false;
                this.Pass341= false;
                this.Pass342= false;
                this.Pass343= false;
                this.Pass344= false;
                this.Pass345= false;
                this.Pass35= false;
                this.Pass351= false;
                this.Pass352= false;
                this.Pass353= false;
                this.Pass354= false;
                this.Pass355= false;
                this.Pass36= false;
                this.Pass361= false;
                this.Pass362= false;
                this.Pass363= false;
                this.Pass364= false;
                this.Pass365= false;
                this.Pass37= false;
                this.Pass371= false;
                this.Pass372= false;
                this.Pass373= false;
                this.Pass374= false;
                this.Pass375= false;
                this.Pass38= false;
                this.Pass381= false;
                this.Pass382= false;
                this.Pass383= false;
                this.Pass384= false;
                this.Pass385= false;
                this.Pass39= false;
                this.Pass391= false;
                this.Pass392= false;
                this.Pass393= false;
                this.Pass394= false;
                this.Pass395= false;
                this.Pass40= false;
                this.Pass401= false;
                this.Pass402= false;
                this.Pass403= false;
                this.Pass404= false;
                this.Pass405= false;
                this.Pass41= false;
                this.Pass411= false;
                this.Pass412= false;
                this.Pass413= false;
                this.Pass414= false;
                this.Pass415= false;
                this.Pass416 = false;
                this.Pass42= false;
                this.Pass421= false;
                this.Pass422= false;
                this.Pass423= false;
                this.Pass424= false;
                this.Pass425= false;
                this.Pass43= false;
                this.Pass431= false;
                this.Pass432= false;
                this.Pass433= false;
                this.Pass434= false;
                this.Pass435= false;
                this.Pass44= false;
                this.Pass441= false;
                this.Pass442= false;
                this.Pass443= false;
                this.Pass444= false;
                this.Pass445= false;
                this.Pass45= false;
                this.Pass451= false;
                this.Pass452= false;
                this.Pass453= false;
                this.Pass454= false;
                this.Pass455= false;
                this.Pass46= false;
                this.Pass461= false;
                this.Pass462= false;
                this.Pass463= false;
                this.Pass464= false;
                this.Pass465= false;
                this.Pass47= false;
                this.Pass471= false;
                this.Pass472= false;
                this.Pass473= false;
                this.Pass474= false;
                this.Pass475= false;
                this.Pass48= false;
                this.Pass481= false;
                this.Pass482= false;
                this.Pass483= false;
                this.Pass484= false;
                this.Pass485= false;
                this.Pass49= false;
                this.Pass491= false;
                this.Pass492= false;
                this.Pass493= false;
                this.Pass494= false;
                this.Pass495= false;
                this.Pass50= false;
                this.Pass501= false;
                this.Pass502 = false;
                this.Pass51= false;
                this.Pass52= false;
                this.Pass521 = false;
                this.Pass53= false;
                this.Pass54= false;
                this.Pass55= false;
                this.Pass56= false;
                this.Pass57= false;
                this.Pass58= false;
                this.Pass59= false;
                this.Pass60= false;
                this.Pass61= false;
                this.Pass62= false;
                this.Pass63= false;
                this.Pass64= false;
                this.Pass65= false;
                this.Pass66= false;
                this.Pass67= false;
                this.Pass68= false;
                this.Pass69= false;
                this.Pass70 = false;
                this.Pass01 = false;
                this.Pass011 = false;
                this.Pass012 = false;
                this.Pass013 = false;
                this.Pass014 = false;
                this.Pass015 = false;
                this.Pass1 = false;
                this.Interface = 0;
        }

        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.RolesAdd(MyEncryption.base64Encode(this.RoleName),this.PassType, this.UserName, this.UserOp, this.UserDate,
	                this.Pass10,
	                this.Pass101,
	                this.Pass102,
	                this.Pass103,
	                this.Pass104,
	                this.Pass11 ,
	                this.Pass111,
	                this.Pass112,
	                this.Pass113,
	                this.Pass114,
	                this.Pass12 ,
	                this.Pass121,
	                this.Pass122,
	                this.Pass123,
	                this.Pass124,
	                this.Pass13 ,
	                this.Pass131,
	                this.Pass132,
	                this.Pass133,
	                this.Pass134,
	                this.Pass14 ,
	                this.Pass141,
	                this.Pass142,
	                this.Pass143,
	                this.Pass144,
	                this.Pass15 ,
	                this.Pass151,
	                this.Pass152,
	                this.Pass153,
	                this.Pass154,
	                this.Pass16 ,
	                this.Pass161,
	                this.Pass162,
	                this.Pass163,
	                this.Pass164,
	                this.Pass17 ,
	                this.Pass171,
	                this.Pass172,
	                this.Pass173,
	                this.Pass174,
	                this.Pass18 ,
	                this.Pass181,
	                this.Pass182,
	                this.Pass183,
	                this.Pass184,
	                this.Pass19 ,
	                this.Pass191,
	                this.Pass192,
	                this.Pass193,
	                this.Pass194,
	                this.Pass20 ,
	                this.Pass201,
	                this.Pass202,
	                this.Pass203,
	                this.Pass204,
	                this.Pass205,
                    this.Pass206,
	                this.Pass21 ,
	                this.Pass211,
	                this.Pass212,
	                this.Pass213,
	                this.Pass214,
	                this.Pass215,
                    this.Pass216,
	                this.Pass22 ,
	                this.Pass221,
	                this.Pass222,
	                this.Pass223,
	                this.Pass224,
	                this.Pass225,
                    this.Pass226,
	                this.Pass23 ,
	                this.Pass231,
	                this.Pass232,
	                this.Pass233,
	                this.Pass234,
	                this.Pass235,
                    this.Pass236,
	                this.Pass24 ,
	                this.Pass241,
	                this.Pass242,
	                this.Pass243,
	                this.Pass244,
	                this.Pass245,
	                this.Pass25 ,
	                this.Pass251,
	                this.Pass252,
	                this.Pass253,
	                this.Pass254,
	                this.Pass255,
	                this.Pass26 ,
	                this.Pass261,
	                this.Pass262,
	                this.Pass263,
	                this.Pass264,
	                this.Pass265,
	                this.Pass27 ,
	                this.Pass271,
	                this.Pass272,
	                this.Pass273,
	                this.Pass274,
	                this.Pass275,
	                this.Pass28,
	                this.Pass281,
	                this.Pass282,
	                this.Pass283,
	                this.Pass284,
	                this.Pass285,
	                this.Pass29,
	                this.Pass291,
	                this.Pass292,
	                this.Pass293,
	                this.Pass294,
	                this.Pass295,
	                this.Pass30,
	                this.Pass301,
	                this.Pass302,
	                this.Pass303,
	                this.Pass304,
	                this.Pass305,
	                this.Pass31,
	                this.Pass311,
	                this.Pass312,
	                this.Pass313,
	                this.Pass314,
	                this.Pass315,
                    this.Pass32,
                    this.Pass321,
                    this.Pass322,
                    this.Pass323,
                    this.Pass324,
                    this.Pass325,
                    this.Pass33,
                    this.Pass331,
                    this.Pass332,
                    this.Pass333,
                    this.Pass334,
                    this.Pass335,
                    this.Pass34,
                    this.Pass341,
                    this.Pass342,
                    this.Pass343,
                    this.Pass344,
                    this.Pass345,
                    this.Pass35,
                    this.Pass351,
                    this.Pass352,
                    this.Pass353,
                    this.Pass354,
                    this.Pass355,
                    this.Pass36,
                    this.Pass361,
                    this.Pass362,
                    this.Pass363,
                    this.Pass364,
                    this.Pass365,
                    this.Pass37,
                    this.Pass371,
                    this.Pass372,
                    this.Pass373,
                    this.Pass374,
                    this.Pass375,
                    this.Pass38,
                    this.Pass381,
                    this.Pass382,
                    this.Pass383,
                    this.Pass384,
                    this.Pass385,
                    this.Pass39,
                    this.Pass391,
                    this.Pass392,
                    this.Pass393,
                    this.Pass394,
                    this.Pass395,
                    this.Pass40,
                    this.Pass401,
                    this.Pass402,
                    this.Pass403,
                    this.Pass404,
                    this.Pass405,
                    this.Pass41,
                    this.Pass411,
                    this.Pass412,
                    this.Pass413,
                    this.Pass414,
                    this.Pass415,
                    this.Pass416,
                    this.Pass42,
                    this.Pass421,
                    this.Pass422,
                    this.Pass423,
                    this.Pass424,
                    this.Pass425,
                    this.Pass43,
                    this.Pass431,
                    this.Pass432,
                    this.Pass433,
                    this.Pass434,
                    this.Pass435,
                    this.Pass44,
                    this.Pass441,
                    this.Pass442,
                    this.Pass443,
                    this.Pass444,
                    this.Pass445,
                    this.Pass45,
                    this.Pass451,
                    this.Pass452,
                    this.Pass453,
                    this.Pass454,
                    this.Pass455,
                    this.Pass46,
                    this.Pass461,
                    this.Pass462,
                    this.Pass463,
                    this.Pass464,
                    this.Pass465,
                    this.Pass47,
                    this.Pass471,
                    this.Pass472,
                    this.Pass473,
                    this.Pass474,
                    this.Pass475,
                    this.Pass48,
                    this.Pass481,
                    this.Pass482,
                    this.Pass483,
                    this.Pass484,
                    this.Pass485,
                    this.Pass49,
                    this.Pass491,
                    this.Pass492,
                    this.Pass493,
                    this.Pass494,
                    this.Pass495,
                    this.Pass50,
                    this.Pass501,
                    this.Pass502,
                    this.Pass51,
                    this.Pass52,
                    this.Pass521,
                    this.Pass53,
                    this.Pass54,
                    this.Pass55,
                    this.Pass56,
                    this.Pass57,
                    this.Pass58,
                    this.Pass59,
                    this.Pass60,
                    this.Pass61,
                    this.Pass62,
                    this.Pass63,
                    this.Pass64,
                    this.Pass65,
                    this.Pass66,
                    this.Pass67,
                    this.Pass68,
                    this.Pass69,
                    this.Pass70,
	                this.Pass01,
	                this.Pass011,
	                this.Pass012,
	                this.Pass013,
	                this.Pass014,
	                this.Pass015,
                    this.Pass1,
                    this.Interface
                    );
                    return true;
                }

            }
            catch { return false; }
        }

        public bool Delete(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.RolesDelete(MyEncryption.base64Encode(this.RoleName));
                    return true;
                }

            }
            catch { return false; }
        }

        public bool Update(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.RolesUpdate(MyEncryption.base64Encode(this.RoleName), this.PassType , this.UserName, this.UserOp, this.UserDate,
                    this.Pass10,
                    this.Pass101,
                    this.Pass102,
                    this.Pass103,
                    this.Pass104,
                    this.Pass11,
                    this.Pass111,
                    this.Pass112,
                    this.Pass113,
                    this.Pass114,
                    this.Pass12,
                    this.Pass121,
                    this.Pass122,
                    this.Pass123,
                    this.Pass124,
                    this.Pass13,
                    this.Pass131,
                    this.Pass132,
                    this.Pass133,
                    this.Pass134,
                    this.Pass14,
                    this.Pass141,
                    this.Pass142,
                    this.Pass143,
                    this.Pass144,
                    this.Pass15,
                    this.Pass151,
                    this.Pass152,
                    this.Pass153,
                    this.Pass154,
                    this.Pass16,
                    this.Pass161,
                    this.Pass162,
                    this.Pass163,
                    this.Pass164,
                    this.Pass17,
                    this.Pass171,
                    this.Pass172,
                    this.Pass173,
                    this.Pass174,
                    this.Pass18,
                    this.Pass181,
                    this.Pass182,
                    this.Pass183,
                    this.Pass184,
                    this.Pass19,
                    this.Pass191,
                    this.Pass192,
                    this.Pass193,
                    this.Pass194,
                    this.Pass20,
                    this.Pass201,
                    this.Pass202,
                    this.Pass203,
                    this.Pass204,
                    this.Pass205,
                    this.Pass206,
                    this.Pass21,
                    this.Pass211,
                    this.Pass212,
                    this.Pass213,
                    this.Pass214,
                    this.Pass215,
                    this.Pass216,
                    this.Pass22,
                    this.Pass221,
                    this.Pass222,
                    this.Pass223,
                    this.Pass224,
                    this.Pass225,
                    this.Pass226,
                    this.Pass23,
                    this.Pass231,
                    this.Pass232,
                    this.Pass233,
                    this.Pass234,
                    this.Pass235,
                    this.Pass236,
                    this.Pass24,
                    this.Pass241,
                    this.Pass242,
                    this.Pass243,
                    this.Pass244,
                    this.Pass245,
                    this.Pass25,
                    this.Pass251,
                    this.Pass252,
                    this.Pass253,
                    this.Pass254,
                    this.Pass255,
                    this.Pass26,
                    this.Pass261,
                    this.Pass262,
                    this.Pass263,
                    this.Pass264,
                    this.Pass265,
                    this.Pass27,
                    this.Pass271,
                    this.Pass272,
                    this.Pass273,
                    this.Pass274,
                    this.Pass275,
                    this.Pass28,
                    this.Pass281,
                    this.Pass282,
                    this.Pass283,
                    this.Pass284,
                    this.Pass285,
                    this.Pass29,
                    this.Pass291,
                    this.Pass292,
                    this.Pass293,
                    this.Pass294,
                    this.Pass295,
                    this.Pass30,
                    this.Pass301,
                    this.Pass302,
                    this.Pass303,
                    this.Pass304,
                    this.Pass305,
                    this.Pass31,
                    this.Pass311,
                    this.Pass312,
                    this.Pass313,
                    this.Pass314,
                    this.Pass315,
                    this.Pass32,
                    this.Pass321,
                    this.Pass322,
                    this.Pass323,
                    this.Pass324,
                    this.Pass325,
                    this.Pass33,
                    this.Pass331,
                    this.Pass332,
                    this.Pass333,
                    this.Pass334,
                    this.Pass335,
                    this.Pass34,
                    this.Pass341,
                    this.Pass342,
                    this.Pass343,
                    this.Pass344,
                    this.Pass345,
                    this.Pass35,
                    this.Pass351,
                    this.Pass352,
                    this.Pass353,
                    this.Pass354,
                    this.Pass355,
                    this.Pass36,
                    this.Pass361,
                    this.Pass362,
                    this.Pass363,
                    this.Pass364,
                    this.Pass365,
                    this.Pass37,
                    this.Pass371,
                    this.Pass372,
                    this.Pass373,
                    this.Pass374,
                    this.Pass375,
                    this.Pass38,
                    this.Pass381,
                    this.Pass382,
                    this.Pass383,
                    this.Pass384,
                    this.Pass385,
                    this.Pass39,
                    this.Pass391,
                    this.Pass392,
                    this.Pass393,
                    this.Pass394,
                    this.Pass395,
                    this.Pass40,
                    this.Pass401,
                    this.Pass402,
                    this.Pass403,
                    this.Pass404,
                    this.Pass405,
                    this.Pass41,
                    this.Pass411,
                    this.Pass412,
                    this.Pass413,
                    this.Pass414,
                    this.Pass415,
                    this.Pass416,
                    this.Pass42,
                    this.Pass421,
                    this.Pass422,
                    this.Pass423,
                    this.Pass424,
                    this.Pass425,
                    this.Pass43,
                    this.Pass431,
                    this.Pass432,
                    this.Pass433,
                    this.Pass434,
                    this.Pass435,
                    this.Pass44,
                    this.Pass441,
                    this.Pass442,
                    this.Pass443,
                    this.Pass444,
                    this.Pass445,
                    this.Pass45,
                    this.Pass451,
                    this.Pass452,
                    this.Pass453,
                    this.Pass454,
                    this.Pass455,
                    this.Pass46,
                    this.Pass461,
                    this.Pass462,
                    this.Pass463,
                    this.Pass464,
                    this.Pass465,
                    this.Pass47,
                    this.Pass471,
                    this.Pass472,
                    this.Pass473,
                    this.Pass474,
                    this.Pass475,
                    this.Pass48,
                    this.Pass481,
                    this.Pass482,
                    this.Pass483,
                    this.Pass484,
                    this.Pass485,
                    this.Pass49,
                    this.Pass491,
                    this.Pass492,
                    this.Pass493,
                    this.Pass494,
                    this.Pass495,
                    this.Pass50,
                    this.Pass501,
                    this.Pass502,
                    this.Pass51,
                    this.Pass52,
                    this.Pass521,
                    this.Pass53,
                    this.Pass54,
                    this.Pass55,
                    this.Pass56,
                    this.Pass57,
                    this.Pass58,
                    this.Pass59,
                    this.Pass60,
                    this.Pass61,
                    this.Pass62,
                    this.Pass63,
                    this.Pass64,
                    this.Pass65,
                    this.Pass66,
                    this.Pass67,
                    this.Pass68,
                    this.Pass69,
                    this.Pass70,
                    this.Pass01,
                    this.Pass011,
                    this.Pass012,
                    this.Pass013,
                    this.Pass014,
                    this.Pass015,
                    this.Pass1,
                    this.Interface
                    );
                    return true;
                }
            }
            catch { return false; }
        }

        public List<TblRoles> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.RolesGetAll();
                    return (from itm in result
                            select new TblRoles
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName)
                            }).ToList();
                }
            }
            catch (Exception) { return null; }
        }


        public List<TblRoles> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.RolesGetAll2();
                    return (from itm in result
                            select new TblRoles
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName),
                                PassType = itm.PassType,
                                UserName = itm.UserName,
                                UserOp = itm.UserOp,
                                UserDate = itm.UserDate,
                                Pass10 = itm.Pass10,
                                Pass101 = itm.Pass101,
                                Pass102 = itm.Pass102,
                                Pass103 = itm.Pass103,
                                Pass104 = itm.Pass104,
                                Pass11 = itm.Pass11,
                                Pass111 = itm.Pass111,
                                Pass112 = itm.Pass112,
                                Pass113 = itm.Pass113,
                                Pass114 = itm.Pass114,
                                Pass12 = itm.Pass12,
                                Pass121 = itm.Pass121,
                                Pass122 = itm.Pass122,
                                Pass123 = itm.Pass123,
                                Pass124 = itm.Pass124,
                                Pass13 = itm.Pass13,
                                Pass131 = itm.Pass131,
                                Pass132 = itm.Pass132,
                                Pass133 = itm.Pass133,
                                Pass134 = itm.Pass134,
                                Pass14 = itm.Pass14,
                                Pass141 = itm.Pass141,
                                Pass142 = itm.Pass142,
                                Pass143 = itm.Pass143,
                                Pass144 = itm.Pass144,
                                Pass15 = itm.Pass15,
                                Pass151 = itm.Pass151,
                                Pass152 = itm.Pass152,
                                Pass153 = itm.Pass153,
                                Pass154 = itm.Pass154,
                                Pass16 = itm.Pass16,
                                Pass161 = itm.Pass161,
                                Pass162 = itm.Pass162,
                                Pass163 = itm.Pass163,
                                Pass164 = itm.Pass164,
                                Pass17 = itm.Pass17,
                                Pass171 = itm.Pass171,
                                Pass172 = itm.Pass172,
                                Pass173 = itm.Pass173,
                                Pass174 = itm.Pass174,
                                Pass18 = itm.Pass18,
                                Pass181 = itm.Pass181,
                                Pass182 = itm.Pass182,
                                Pass183 = itm.Pass183,
                                Pass184 = itm.Pass184,
                                Pass19 = itm.Pass19,
                                Pass191 = itm.Pass191,
                                Pass192 = itm.Pass192,
                                Pass193 = itm.Pass193,
                                Pass194 = itm.Pass194,
                                Pass20 = itm.Pass20,
                                Pass201 = itm.Pass201,
                                Pass202 = itm.Pass202,
                                Pass203 = itm.Pass203,
                                Pass204 = itm.Pass204,
                                Pass205 = itm.Pass205,
                                Pass21 = itm.Pass21,
                                Pass211 = itm.Pass211,
                                Pass212 = itm.Pass212,
                                Pass213 = itm.Pass213,
                                Pass214 = itm.Pass214,
                                Pass215 = itm.Pass215,
                                Pass22 = itm.Pass22,
                                Pass221 = itm.Pass221,
                                Pass222 = itm.Pass222,
                                Pass223 = itm.Pass223,
                                Pass224 = itm.Pass224,
                                Pass225 = itm.Pass225,
                                Pass23 = itm.Pass23,
                                Pass231 = itm.Pass231,
                                Pass232 = itm.Pass232,
                                Pass233 = itm.Pass233,
                                Pass234 = itm.Pass234,
                                Pass235 = itm.Pass235,
                                Pass24 = itm.Pass24,
                                Pass241 = itm.Pass241,
                                Pass242 = itm.Pass242,
                                Pass243 = itm.Pass243,
                                Pass244 = itm.Pass244,
                                Pass245 = itm.Pass245,
                                Pass25 = itm.Pass25,
                                Pass251 = itm.Pass251,
                                Pass252 = itm.Pass252,
                                Pass253 = itm.Pass253,
                                Pass254 = itm.Pass254,
                                Pass255 = itm.Pass255,
                                Pass26 = itm.Pass26,
                                Pass261 = itm.Pass261,
                                Pass262 = itm.Pass262,
                                Pass263 = itm.Pass263,
                                Pass264 = itm.Pass264,
                                Pass265 = itm.Pass265,
                                Pass27 = itm.Pass27,
                                Pass271 = itm.Pass271,
                                Pass272 = itm.Pass272,
                                Pass273 = itm.Pass273,
                                Pass274 = itm.Pass274,
                                Pass275 = itm.Pass275,
                                Pass28 = itm.Pass28,
                                Pass281 = itm.Pass281,
                                Pass282 = itm.Pass282,
                                Pass283 = itm.Pass283,
                                Pass284 = itm.Pass284,
                                Pass285 = itm.Pass285,
                                Pass29 = itm.Pass29,
                                Pass291 = itm.Pass291,
                                Pass292 = itm.Pass292,
                                Pass293 = itm.Pass293,
                                Pass294 = itm.Pass294,
                                Pass295 = itm.Pass295,
                                Pass30 = itm.Pass30,
                                Pass301 = itm.Pass301,
                                Pass302 = itm.Pass302,
                                Pass303 = itm.Pass303,
                                Pass304 = itm.Pass304,
                                Pass305 = itm.Pass305,
                                Pass31 = itm.Pass31,
                                Pass311 = itm.Pass311,
                                Pass312 = itm.Pass312,
                                Pass313 = itm.Pass313,
                                Pass314 = itm.Pass314,
                                Pass315 = itm.Pass315,
                                Pass32 = itm.Pass32,
                                Pass321 = itm.Pass321,
                                Pass322 = itm.Pass322,
                                Pass323 = itm.Pass323,
                                Pass324 = itm.Pass324,
                                Pass325 = itm.Pass325,
                                Pass33 = itm.Pass33,
                                Pass331 = itm.Pass331,
                                Pass332 = itm.Pass332,
                                Pass333 = itm.Pass333,
                                Pass334 = itm.Pass334,
                                Pass335 = itm.Pass335,
                                Pass34 = itm.Pass34,
                                Pass341 = itm.Pass341,
                                Pass342 = itm.Pass342,
                                Pass343 = itm.Pass343,
                                Pass344 = itm.Pass344,
                                Pass345 = itm.Pass345,
                                Pass35 = itm.Pass35,
                                Pass351 = itm.Pass351,
                                Pass352 = itm.Pass352,
                                Pass353 = itm.Pass353,
                                Pass354 = itm.Pass354,
                                Pass355 = itm.Pass355,
                                Pass36 = itm.Pass36,
                                Pass361 = itm.Pass361,
                                Pass362 = itm.Pass362,
                                Pass363 = itm.Pass363,
                                Pass364 = itm.Pass364,
                                Pass365 = itm.Pass365,
                                Pass37 = itm.Pass37,
                                Pass371 = itm.Pass371,
                                Pass372 = itm.Pass372,
                                Pass373 = itm.Pass373,
                                Pass374 = itm.Pass374,
                                Pass375 = itm.Pass375,
                                Pass38 = itm.Pass38,
                                Pass381 = itm.Pass381,
                                Pass382 = itm.Pass382,
                                Pass383 = itm.Pass383,
                                Pass384 = itm.Pass384,
                                Pass385 = itm.Pass385,
                                Pass39 = itm.Pass39,
                                Pass391 = itm.Pass391,
                                Pass392 = itm.Pass392,
                                Pass393 = itm.Pass393,
                                Pass394 = itm.Pass394,
                                Pass395 = itm.Pass395,
                                Pass40 = itm.Pass40,
                                Pass401 = itm.Pass401,
                                Pass402 = itm.Pass402,
                                Pass403 = itm.Pass403,
                                Pass404 = itm.Pass404,
                                Pass405 = itm.Pass405,
                                Pass41 = itm.Pass41,
                                Pass411 = itm.Pass411,
                                Pass412 = itm.Pass412,
                                Pass413 = itm.Pass413,
                                Pass414 = itm.Pass414,
                                Pass415 = itm.Pass415,
                                Pass42 = itm.Pass42,
                                Pass421 = itm.Pass421,
                                Pass422 = itm.Pass422,
                                Pass423 = itm.Pass423,
                                Pass424 = itm.Pass424,
                                Pass425 = itm.Pass425,
                                Pass43 = itm.Pass43,
                                Pass431 = itm.Pass431,
                                Pass432 = itm.Pass432,
                                Pass433 = itm.Pass433,
                                Pass434 = itm.Pass434,
                                Pass435 = itm.Pass435,
                                Pass44 = itm.Pass44,
                                Pass441 = itm.Pass441,
                                Pass442 = itm.Pass442,
                                Pass443 = itm.Pass443,
                                Pass444 = itm.Pass444,
                                Pass445 = itm.Pass445,
                                Pass45 = itm.Pass45,
                                Pass451 = itm.Pass451,
                                Pass452 = itm.Pass452,
                                Pass453 = itm.Pass453,
                                Pass454 = itm.Pass454,
                                Pass455 = itm.Pass455,
                                Pass46 = itm.Pass46,
                                Pass461 = itm.Pass461,
                                Pass462 = itm.Pass462,
                                Pass463 = itm.Pass463,
                                Pass464 = itm.Pass464,
                                Pass465 = itm.Pass465,
                                Pass47 = itm.Pass47,
                                Pass471 = itm.Pass471,
                                Pass472 = itm.Pass472,
                                Pass473 = itm.Pass473,
                                Pass474 = itm.Pass474,
                                Pass475 = itm.Pass475,
                                Pass48 = itm.Pass48,
                                Pass481 = itm.Pass481,
                                Pass482 = itm.Pass482,
                                Pass483 = itm.Pass483,
                                Pass484 = itm.Pass484,
                                Pass485 = itm.Pass485,
                                Pass49 = itm.Pass49,
                                Pass491 = itm.Pass491,
                                Pass492 = itm.Pass492,
                                Pass493 = itm.Pass493,
                                Pass494 = itm.Pass494,
                                Pass495 = itm.Pass495,
                                Pass50 = itm.Pass50,
                                Pass501 = itm.Pass501,
                                Pass51 = itm.Pass51,
                                Pass52 = itm.Pass52,
                                Pass53 = itm.Pass53,
                                Pass54 = itm.Pass54,
                                Pass55 = itm.Pass55,
                                Pass56 = itm.Pass56,
                                Pass57 = itm.Pass57,
                                Pass58 = itm.Pass58,
                                Pass59 = itm.Pass59,
                                Pass60 = itm.Pass60,
                                Pass61 = itm.Pass61,
                                Pass62 = itm.Pass62,
                                Pass63 = itm.Pass63,
                                Pass64 = itm.Pass64,
                                Pass65 = itm.Pass65,
                                Pass66 = itm.Pass66,
                                Pass67 = itm.Pass67,
                                Pass68 = itm.Pass68,
                                Pass69 = itm.Pass69,
                                Pass70 = itm.Pass70,
                                Pass01 = itm.Pass01,
                                Pass011 = itm.Pass011,
                                Pass012 = itm.Pass012,
                                Pass013 = itm.Pass013,
                                Pass014 = itm.Pass014,
                                Pass015 = itm.Pass015,
                                Pass1 = itm.Pass1,
                                Pass206 = itm.Pass206,
                                Pass216 = itm.Pass216,
                                Pass226 = itm.Pass226,
                                Pass236 = itm.Pass236,
                                Pass416 = itm.Pass416,
                                Pass502 = itm.Pass502,
                                Pass521 = itm.Pass521,
                                Interface = itm.Interface                                  
                            }).ToList();
                }
            }
            catch (Exception) { return null; }
        }



        public List<TblRoles> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.RolesFind(MyEncryption.base64Encode(this.RoleName));
                    return (from itm in result
                            select new TblRoles
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName),
                                PassType = itm.PassType,
                                UserName = itm.UserName,
                                UserOp = itm.UserOp,
                                UserDate = itm.UserDate,
                                Pass10 = itm.Pass10,
                                Pass101 = itm.Pass101,
                                Pass102 = itm.Pass102,
                                Pass103 = itm.Pass103,
                                Pass104 = itm.Pass104,
                                Pass11 = itm.Pass11,
                                Pass111 = itm.Pass111,
                                Pass112 = itm.Pass112,
                                Pass113 = itm.Pass113,
                                Pass114 = itm.Pass114,
                                Pass12 = itm.Pass12,
                                Pass121 = itm.Pass121,
                                Pass122 = itm.Pass122,
                                Pass123 = itm.Pass123,
                                Pass124 = itm.Pass124,
                                Pass13 = itm.Pass13,
                                Pass131 = itm.Pass131,
                                Pass132 = itm.Pass132,
                                Pass133 = itm.Pass133,
                                Pass134 = itm.Pass134,
                                Pass14 = itm.Pass14,
                                Pass141 = itm.Pass141,
                                Pass142 = itm.Pass142,
                                Pass143 = itm.Pass143,
                                Pass144 = itm.Pass144,
                                Pass15 = itm.Pass15,
                                Pass151 = itm.Pass151,
                                Pass152 = itm.Pass152,
                                Pass153 = itm.Pass153,
                                Pass154 = itm.Pass154,
                                Pass16 = itm.Pass16,
                                Pass161 = itm.Pass161,
                                Pass162 = itm.Pass162,
                                Pass163 = itm.Pass163,
                                Pass164 = itm.Pass164,
                                Pass17 = itm.Pass17,
                                Pass171 = itm.Pass171,
                                Pass172 = itm.Pass172,
                                Pass173 = itm.Pass173,
                                Pass174 = itm.Pass174,
                                Pass18 = itm.Pass18,
                                Pass181 = itm.Pass181,
                                Pass182 = itm.Pass182,
                                Pass183 = itm.Pass183,
                                Pass184 = itm.Pass184,
                                Pass19 = itm.Pass19,
                                Pass191 = itm.Pass191,
                                Pass192 = itm.Pass192,
                                Pass193 = itm.Pass193,
                                Pass194 = itm.Pass194,
                                Pass20 = itm.Pass20,
                                Pass201 = itm.Pass201,
                                Pass202 = itm.Pass202,
                                Pass203 = itm.Pass203,
                                Pass204 = itm.Pass204,
                                Pass205 = itm.Pass205,
                                Pass21 = itm.Pass21,
                                Pass211 = itm.Pass211,
                                Pass212 = itm.Pass212,
                                Pass213 = itm.Pass213,
                                Pass214 = itm.Pass214,
                                Pass215 = itm.Pass215,
                                Pass22 = itm.Pass22,
                                Pass221 = itm.Pass221,
                                Pass222 = itm.Pass222,
                                Pass223 = itm.Pass223,
                                Pass224 = itm.Pass224,
                                Pass225 = itm.Pass225,
                                Pass23 = itm.Pass23,
                                Pass231 = itm.Pass231,
                                Pass232 = itm.Pass232,
                                Pass233 = itm.Pass233,
                                Pass234 = itm.Pass234,
                                Pass235 = itm.Pass235,
                                Pass24 = itm.Pass24,
                                Pass241 = itm.Pass241,
                                Pass242 = itm.Pass242,
                                Pass243 = itm.Pass243,
                                Pass244 = itm.Pass244,
                                Pass245 = itm.Pass245,
                                Pass25 = itm.Pass25,
                                Pass251 = itm.Pass251,
                                Pass252 = itm.Pass252,
                                Pass253 = itm.Pass253,
                                Pass254 = itm.Pass254,
                                Pass255 = itm.Pass255,
                                Pass26 = itm.Pass26,
                                Pass261 = itm.Pass261,
                                Pass262 = itm.Pass262,
                                Pass263 = itm.Pass263,
                                Pass264 = itm.Pass264,
                                Pass265 = itm.Pass265,
                                Pass27 = itm.Pass27,
                                Pass271 = itm.Pass271,
                                Pass272 = itm.Pass272,
                                Pass273 = itm.Pass273,
                                Pass274 = itm.Pass274,
                                Pass275 = itm.Pass275,
                                Pass28 = itm.Pass28,
                                Pass281 = itm.Pass281,
                                Pass282 = itm.Pass282,
                                Pass283 = itm.Pass283,
                                Pass284 = itm.Pass284,
                                Pass285 = itm.Pass285,
                                Pass29 = itm.Pass29,
                                Pass291 = itm.Pass291,
                                Pass292 = itm.Pass292,
                                Pass293 = itm.Pass293,
                                Pass294 = itm.Pass294,
                                Pass295 = itm.Pass295,
                                Pass30 = itm.Pass30,
                                Pass301 = itm.Pass301,
                                Pass302 = itm.Pass302,
                                Pass303 = itm.Pass303,
                                Pass304 = itm.Pass304,
                                Pass305 = itm.Pass305,
                                Pass31 = itm.Pass31,
                                Pass311 = itm.Pass311,
                                Pass312 = itm.Pass312,
                                Pass313 = itm.Pass313,
                                Pass314 = itm.Pass314,
                                Pass315 = itm.Pass315,
                                Pass32 = itm.Pass32,
                                Pass321 = itm.Pass321,
                                Pass322 = itm.Pass322,
                                Pass323 = itm.Pass323,
                                Pass324 = itm.Pass324,
                                Pass325 = itm.Pass325,
                                Pass33 = itm.Pass33,
                                Pass331 = itm.Pass331,
                                Pass332 = itm.Pass332,
                                Pass333 = itm.Pass333,
                                Pass334 = itm.Pass334,
                                Pass335 = itm.Pass335,
                                Pass34 = itm.Pass34,
                                Pass341 = itm.Pass341,
                                Pass342 = itm.Pass342,
                                Pass343 = itm.Pass343,
                                Pass344 = itm.Pass344,
                                Pass345 = itm.Pass345,
                                Pass35 = itm.Pass35,
                                Pass351 = itm.Pass351,
                                Pass352 = itm.Pass352,
                                Pass353 = itm.Pass353,
                                Pass354 = itm.Pass354,
                                Pass355 = itm.Pass355,
                                Pass36 = itm.Pass36,
                                Pass361 = itm.Pass361,
                                Pass362 = itm.Pass362,
                                Pass363 = itm.Pass363,
                                Pass364 = itm.Pass364,
                                Pass365 = itm.Pass365,
                                Pass37 = itm.Pass37,
                                Pass371 = itm.Pass371,
                                Pass372 = itm.Pass372,
                                Pass373 = itm.Pass373,
                                Pass374 = itm.Pass374,
                                Pass375 = itm.Pass375,
                                Pass38 = itm.Pass38,
                                Pass381 = itm.Pass381,
                                Pass382 = itm.Pass382,
                                Pass383 = itm.Pass383,
                                Pass384 = itm.Pass384,
                                Pass385 = itm.Pass385,
                                Pass39 = itm.Pass39,
                                Pass391 = itm.Pass391,
                                Pass392 = itm.Pass392,
                                Pass393 = itm.Pass393,
                                Pass394 = itm.Pass394,
                                Pass395 = itm.Pass395,
                                Pass40 = itm.Pass40,
                                Pass401 = itm.Pass401,
                                Pass402 = itm.Pass402,
                                Pass403 = itm.Pass403,
                                Pass404 = itm.Pass404,
                                Pass405 = itm.Pass405,
                                Pass41 = itm.Pass41,
                                Pass411 = itm.Pass411,
                                Pass412 = itm.Pass412,
                                Pass413 = itm.Pass413,
                                Pass414 = itm.Pass414,
                                Pass415 = itm.Pass415,
                                Pass42 = itm.Pass42,
                                Pass421 = itm.Pass421,
                                Pass422 = itm.Pass422,
                                Pass423 = itm.Pass423,
                                Pass424 = itm.Pass424,
                                Pass425 = itm.Pass425,
                                Pass43 = itm.Pass43,
                                Pass431 = itm.Pass431,
                                Pass432 = itm.Pass432,
                                Pass433 = itm.Pass433,
                                Pass434 = itm.Pass434,
                                Pass435 = itm.Pass435,
                                Pass44 = itm.Pass44,
                                Pass441 = itm.Pass441,
                                Pass442 = itm.Pass442,
                                Pass443 = itm.Pass443,
                                Pass444 = itm.Pass444,
                                Pass445 = itm.Pass445,
                                Pass45 = itm.Pass45,
                                Pass451 = itm.Pass451,
                                Pass452 = itm.Pass452,
                                Pass453 = itm.Pass453,
                                Pass454 = itm.Pass454,
                                Pass455 = itm.Pass455,
                                Pass46 = itm.Pass46,
                                Pass461 = itm.Pass461,
                                Pass462 = itm.Pass462,
                                Pass463 = itm.Pass463,
                                Pass464 = itm.Pass464,
                                Pass465 = itm.Pass465,
                                Pass47 = itm.Pass47,
                                Pass471 = itm.Pass471,
                                Pass472 = itm.Pass472,
                                Pass473 = itm.Pass473,
                                Pass474 = itm.Pass474,
                                Pass475 = itm.Pass475,
                                Pass48 = itm.Pass48,
                                Pass481 = itm.Pass481,
                                Pass482 = itm.Pass482,
                                Pass483 = itm.Pass483,
                                Pass484 = itm.Pass484,
                                Pass485 = itm.Pass485,
                                Pass49 = itm.Pass49,
                                Pass491 = itm.Pass491,
                                Pass492 = itm.Pass492,
                                Pass493 = itm.Pass493,
                                Pass494 = itm.Pass494,
                                Pass495 = itm.Pass495,
                                Pass50 = itm.Pass50,
                                Pass501 = itm.Pass501,
                                Pass51 = itm.Pass51,
                                Pass52 = itm.Pass52,
                                Pass53 = itm.Pass53,
                                Pass54 = itm.Pass54,
                                Pass55 = itm.Pass55,
                                Pass56 = itm.Pass56,
                                Pass57 = itm.Pass57,
                                Pass58 = itm.Pass58,
                                Pass59 = itm.Pass59,
                                Pass60 = itm.Pass60,
                                Pass61 = itm.Pass61,
                                Pass62 = itm.Pass62,
                                Pass63 = itm.Pass63,
                                Pass64 = itm.Pass64,
                                Pass65 = itm.Pass65,
                                Pass66 = itm.Pass66,
                                Pass67 = itm.Pass67,
                                Pass68 = itm.Pass68,
                                Pass69 = itm.Pass69,
                                Pass70 = itm.Pass70,
                                Pass01 = itm.Pass01,
                                Pass011 = itm.Pass011,
                                Pass012 = itm.Pass012,
                                Pass013 = itm.Pass013,
                                Pass014 = itm.Pass014,
                                Pass015 = itm.Pass015,
                                Pass1 = itm.Pass1,
                                Pass206 = itm.Pass206,
                                Pass216 = itm.Pass216,
                                Pass226 = itm.Pass226,
                                Pass236 = itm.Pass236,
                                Pass416 = itm.Pass416,
                                Pass502 = itm.Pass502,
                                Pass521 = itm.Pass521,
                                Interface = itm.Interface  
                           }).ToList();
                }
            }
            catch (Exception) { return null; }
        }



        public TblRoles Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.RolesFind2(MyEncryption.base64Encode(this.RoleName),this.PassType);
                    return (from itm in result
                            select new TblRoles
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName),
                                PassType = itm.PassType,
                                UserName = itm.UserName,
                                UserOp = itm.UserOp,
                                UserDate = itm.UserDate,
                                Pass10 = itm.Pass10,
                                Pass101 = itm.Pass101,
                                Pass102 = itm.Pass102,
                                Pass103 = itm.Pass103,
                                Pass104 = itm.Pass104,
                                Pass11 = itm.Pass11,
                                Pass111 = itm.Pass111,
                                Pass112 = itm.Pass112,
                                Pass113 = itm.Pass113,
                                Pass114 = itm.Pass114,
                                Pass12 = itm.Pass12,
                                Pass121 = itm.Pass121,
                                Pass122 = itm.Pass122,
                                Pass123 = itm.Pass123,
                                Pass124 = itm.Pass124,
                                Pass13 = itm.Pass13,
                                Pass131 = itm.Pass131,
                                Pass132 = itm.Pass132,
                                Pass133 = itm.Pass133,
                                Pass134 = itm.Pass134,
                                Pass14 = itm.Pass14,
                                Pass141 = itm.Pass141,
                                Pass142 = itm.Pass142,
                                Pass143 = itm.Pass143,
                                Pass144 = itm.Pass144,
                                Pass15 = itm.Pass15,
                                Pass151 = itm.Pass151,
                                Pass152 = itm.Pass152,
                                Pass153 = itm.Pass153,
                                Pass154 = itm.Pass154,
                                Pass16 = itm.Pass16,
                                Pass161 = itm.Pass161,
                                Pass162 = itm.Pass162,
                                Pass163 = itm.Pass163,
                                Pass164 = itm.Pass164,
                                Pass17 = itm.Pass17,
                                Pass171 = itm.Pass171,
                                Pass172 = itm.Pass172,
                                Pass173 = itm.Pass173,
                                Pass174 = itm.Pass174,
                                Pass18 = itm.Pass18,
                                Pass181 = itm.Pass181,
                                Pass182 = itm.Pass182,
                                Pass183 = itm.Pass183,
                                Pass184 = itm.Pass184,
                                Pass19 = itm.Pass19,
                                Pass191 = itm.Pass191,
                                Pass192 = itm.Pass192,
                                Pass193 = itm.Pass193,
                                Pass194 = itm.Pass194,
                                Pass20 = itm.Pass20,
                                Pass201 = itm.Pass201,
                                Pass202 = itm.Pass202,
                                Pass203 = itm.Pass203,
                                Pass204 = itm.Pass204,
                                Pass205 = itm.Pass205,
                                Pass21 = itm.Pass21,
                                Pass211 = itm.Pass211,
                                Pass212 = itm.Pass212,
                                Pass213 = itm.Pass213,
                                Pass214 = itm.Pass214,
                                Pass215 = itm.Pass215,
                                Pass22 = itm.Pass22,
                                Pass221 = itm.Pass221,
                                Pass222 = itm.Pass222,
                                Pass223 = itm.Pass223,
                                Pass224 = itm.Pass224,
                                Pass225 = itm.Pass225,
                                Pass23 = itm.Pass23,
                                Pass231 = itm.Pass231,
                                Pass232 = itm.Pass232,
                                Pass233 = itm.Pass233,
                                Pass234 = itm.Pass234,
                                Pass235 = itm.Pass235,
                                Pass24 = itm.Pass24,
                                Pass241 = itm.Pass241,
                                Pass242 = itm.Pass242,
                                Pass243 = itm.Pass243,
                                Pass244 = itm.Pass244,
                                Pass245 = itm.Pass245,
                                Pass25 = itm.Pass25,
                                Pass251 = itm.Pass251,
                                Pass252 = itm.Pass252,
                                Pass253 = itm.Pass253,
                                Pass254 = itm.Pass254,
                                Pass255 = itm.Pass255,
                                Pass26 = itm.Pass26,
                                Pass261 = itm.Pass261,
                                Pass262 = itm.Pass262,
                                Pass263 = itm.Pass263,
                                Pass264 = itm.Pass264,
                                Pass265 = itm.Pass265,
                                Pass27 = itm.Pass27,
                                Pass271 = itm.Pass271,
                                Pass272 = itm.Pass272,
                                Pass273 = itm.Pass273,
                                Pass274 = itm.Pass274,
                                Pass275 = itm.Pass275,
                                Pass28 = itm.Pass28,
                                Pass281 = itm.Pass281,
                                Pass282 = itm.Pass282,
                                Pass283 = itm.Pass283,
                                Pass284 = itm.Pass284,
                                Pass285 = itm.Pass285,
                                Pass29 = itm.Pass29,
                                Pass291 = itm.Pass291,
                                Pass292 = itm.Pass292,
                                Pass293 = itm.Pass293,
                                Pass294 = itm.Pass294,
                                Pass295 = itm.Pass295,
                                Pass30 = itm.Pass30,
                                Pass301 = itm.Pass301,
                                Pass302 = itm.Pass302,
                                Pass303 = itm.Pass303,
                                Pass304 = itm.Pass304,
                                Pass305 = itm.Pass305,
                                Pass31 = itm.Pass31,
                                Pass311 = itm.Pass311,
                                Pass312 = itm.Pass312,
                                Pass313 = itm.Pass313,
                                Pass314 = itm.Pass314,
                                Pass315 = itm.Pass315,
                                Pass32 = itm.Pass32,
                                Pass321 = itm.Pass321,
                                Pass322 = itm.Pass322,
                                Pass323 = itm.Pass323,
                                Pass324 = itm.Pass324,
                                Pass325 = itm.Pass325,
                                Pass33 = itm.Pass33,
                                Pass331 = itm.Pass331,
                                Pass332 = itm.Pass332,
                                Pass333 = itm.Pass333,
                                Pass334 = itm.Pass334,
                                Pass335 = itm.Pass335,
                                Pass34 = itm.Pass34,
                                Pass341 = itm.Pass341,
                                Pass342 = itm.Pass342,
                                Pass343 = itm.Pass343,
                                Pass344 = itm.Pass344,
                                Pass345 = itm.Pass345,
                                Pass35 = itm.Pass35,
                                Pass351 = itm.Pass351,
                                Pass352 = itm.Pass352,
                                Pass353 = itm.Pass353,
                                Pass354 = itm.Pass354,
                                Pass355 = itm.Pass355,
                                Pass36 = itm.Pass36,
                                Pass361 = itm.Pass361,
                                Pass362 = itm.Pass362,
                                Pass363 = itm.Pass363,
                                Pass364 = itm.Pass364,
                                Pass365 = itm.Pass365,
                                Pass37 = itm.Pass37,
                                Pass371 = itm.Pass371,
                                Pass372 = itm.Pass372,
                                Pass373 = itm.Pass373,
                                Pass374 = itm.Pass374,
                                Pass375 = itm.Pass375,
                                Pass38 = itm.Pass38,
                                Pass381 = itm.Pass381,
                                Pass382 = itm.Pass382,
                                Pass383 = itm.Pass383,
                                Pass384 = itm.Pass384,
                                Pass385 = itm.Pass385,
                                Pass39 = itm.Pass39,
                                Pass391 = itm.Pass391,
                                Pass392 = itm.Pass392,
                                Pass393 = itm.Pass393,
                                Pass394 = itm.Pass394,
                                Pass395 = itm.Pass395,
                                Pass40 = itm.Pass40,
                                Pass401 = itm.Pass401,
                                Pass402 = itm.Pass402,
                                Pass403 = itm.Pass403,
                                Pass404 = itm.Pass404,
                                Pass405 = itm.Pass405,
                                Pass41 = itm.Pass41,
                                Pass411 = itm.Pass411,
                                Pass412 = itm.Pass412,
                                Pass413 = itm.Pass413,
                                Pass414 = itm.Pass414,
                                Pass415 = itm.Pass415,
                                Pass42 = itm.Pass42,
                                Pass421 = itm.Pass421,
                                Pass422 = itm.Pass422,
                                Pass423 = itm.Pass423,
                                Pass424 = itm.Pass424,
                                Pass425 = itm.Pass425,
                                Pass43 = itm.Pass43,
                                Pass431 = itm.Pass431,
                                Pass432 = itm.Pass432,
                                Pass433 = itm.Pass433,
                                Pass434 = itm.Pass434,
                                Pass435 = itm.Pass435,
                                Pass44 = itm.Pass44,
                                Pass441 = itm.Pass441,
                                Pass442 = itm.Pass442,
                                Pass443 = itm.Pass443,
                                Pass444 = itm.Pass444,
                                Pass445 = itm.Pass445,
                                Pass45 = itm.Pass45,
                                Pass451 = itm.Pass451,
                                Pass452 = itm.Pass452,
                                Pass453 = itm.Pass453,
                                Pass454 = itm.Pass454,
                                Pass455 = itm.Pass455,
                                Pass46 = itm.Pass46,
                                Pass461 = itm.Pass461,
                                Pass462 = itm.Pass462,
                                Pass463 = itm.Pass463,
                                Pass464 = itm.Pass464,
                                Pass465 = itm.Pass465,
                                Pass47 = itm.Pass47,
                                Pass471 = itm.Pass471,
                                Pass472 = itm.Pass472,
                                Pass473 = itm.Pass473,
                                Pass474 = itm.Pass474,
                                Pass475 = itm.Pass475,
                                Pass48 = itm.Pass48,
                                Pass481 = itm.Pass481,
                                Pass482 = itm.Pass482,
                                Pass483 = itm.Pass483,
                                Pass484 = itm.Pass484,
                                Pass485 = itm.Pass485,
                                Pass49 = itm.Pass49,
                                Pass491 = itm.Pass491,
                                Pass492 = itm.Pass492,
                                Pass493 = itm.Pass493,
                                Pass494 = itm.Pass494,
                                Pass495 = itm.Pass495,
                                Pass50 = itm.Pass50,
                                Pass501 = itm.Pass501,
                                Pass51 = itm.Pass51,
                                Pass52 = itm.Pass52,
                                Pass53 = itm.Pass53,
                                Pass54 = itm.Pass54,
                                Pass55 = itm.Pass55,
                                Pass56 = itm.Pass56,
                                Pass57 = itm.Pass57,
                                Pass58 = itm.Pass58,
                                Pass59 = itm.Pass59,
                                Pass60 = itm.Pass60,
                                Pass61 = itm.Pass61,
                                Pass62 = itm.Pass62,
                                Pass63 = itm.Pass63,
                                Pass64 = itm.Pass64,
                                Pass65 = itm.Pass65,
                                Pass66 = itm.Pass66,
                                Pass67 = itm.Pass67,
                                Pass68 = itm.Pass68,
                                Pass69 = itm.Pass69,
                                Pass70 = itm.Pass70,
                                Pass01 = itm.Pass01,
                                Pass011 = itm.Pass011,
                                Pass012 = itm.Pass012,
                                Pass013 = itm.Pass013,
                                Pass014 = itm.Pass014,
                                Pass015 = itm.Pass015,
                                Pass1 = itm.Pass1,
                                Pass206 = itm.Pass206,
                                Pass216 = itm.Pass216,
                                Pass226 = itm.Pass226,
                                Pass236 = itm.Pass236,
                                Pass416 = itm.Pass416,
                                Pass502 = itm.Pass502,
                                Pass521 = itm.Pass521,
                                Interface = itm.Interface  
                            }).FirstOrDefault();
                }
            }
            catch (Exception) { return null; }
        }

    }

    [Serializable]
    public class TblUsersInRole
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public bool Add(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.UsersInRoleAdd(MyEncryption.base64Encode(this.RoleName), MyEncryption.base64Encode(this.UserName));
                    return true;
                }

            }
            catch { return false; }
        }

        public bool Delete(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.UsersInRoleDelete(MyEncryption.base64Encode(this.UserName));
                    return true;
                }

            }
            catch { return false; }
        }


        public List<TblUsersInRole> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.UsersInRoleGetAll(MyEncryption.base64Encode(this.UserName));
                    return (from itm in result
                            select new TblUsersInRole
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName),
                                UserName = MyEncryption.base64Decode(itm.UserName)
                            }).ToList();
                }
            }
            catch (Exception) { return null; }
        }

        public List<TblUsersInRole> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.UsersInRoleGetAll2();
                    return (from itm in result
                            select new TblUsersInRole
                            {
                                RoleName = MyEncryption.base64Decode(itm.RoleName),
                                UserName = MyEncryption.base64Decode(itm.UserName)
                            }).OrderBy(p=> p.RoleName).ToList();
                }
            }
            catch (Exception) { return null; }
        }

    }

    [Serializable]
    public class TblUsers
    {
        public string UserName { get; set; }
        public string FName { get; set; }
        public string Password { get; set; }
        public string tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserName2 { get; set; }
        public string UserOP { get; set; }
        public string UserDate { get; set; }
        public bool? ChangePass { get; set; }
        public string Branchs { get; set; }
        public string MainBran { get; set; }
        public string BranRoll { get; set; }
        public string Photo { get; set; }
        public string EmailPassword { get; set; }
        public bool? Active { get; set; }
        public string Sign { get; set; }
        public string Account1 { get; set; }
        public string Account2 { get; set; }
        public string Account3 { get; set; }
        public string Account4 { get; set; }
        public string Account5 { get; set; }
        public string Account6 { get; set; }

        public TblUsers()
        {
            this.UserName = "";
            this.FName = "";
            this.Password = "";
            this.tel = "";
            this.Mobile = "";
            this.Email = "";
            this.UserName2 = "";
            this.UserOP = "";
            this.UserDate = "";
            this.ChangePass = false;
            this.Branchs = "";
            this.MainBran = "";
            this.BranRoll = "";
            this.Photo = "";
            this.EmailPassword = "";
            this.Active = false;
            this.Sign = "";
            this.Account1 = "-1";
            this.Account2 = "-1";
            this.Account3 = "-1";
            this.Account4 = "-1";
            this.Account5 = "-1";
            this.Account6 = "-1";
        }


    
        public bool Add(string ConnectionStr)
        {
             try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.UsersAdd(MyEncryption.base64Encode(this.UserName), MyEncryption.base64Encode(this.FName), MyEncryption.base64Encode(this.Password), MyEncryption.base64Encode(this.tel), MyEncryption.base64Encode(this.Mobile), MyEncryption.base64Encode(this.Email), this.UserName2, this.UserOP, this.UserDate,this.ChangePass,this.Branchs,this.MainBran,this.BranRoll,this.Photo,MyEncryption.base64Encode(this.EmailPassword),this.Active,this.Sign,this.Account1,this.Account2,this.Account3,this.Account4,this.Account5,this.Account6);
                    return true;
                }
            }
            catch { return false; }
        }

        public bool Delete(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.UsersDelete(MyEncryption.base64Encode(this.UserName));
                    return true;
                }

            }
            catch { return false; }
        }

        public bool Update(string ConnectionStr)
        {
            try
            {

                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    context.UsersUpdate(MyEncryption.base64Encode(this.UserName), MyEncryption.base64Encode(this.FName), MyEncryption.base64Encode(this.Password), MyEncryption.base64Encode(this.tel), MyEncryption.base64Encode(this.Mobile), MyEncryption.base64Encode(this.Email), this.UserName2, this.UserOP, this.UserDate, this.ChangePass, this.Branchs, this.MainBran, this.BranRoll, this.Photo, MyEncryption.base64Encode(this.EmailPassword), this.Active, this.Sign, this.Account1, this.Account2, this.Account3, this.Account4, this.Account5, this.Account6);
                    return true;
                }
            }
            catch { return false; }
        }

        public List<TblUsers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.UsersGetAll();
                    return (from itm in result
                            orderby MyEncryption.base64Decode(itm.FName)
                            select new TblUsers
                            {
                                UserName = MyEncryption.base64Decode(itm.UserName),
                                FName = MyEncryption.base64Decode(itm.FName),
                                Password = MyEncryption.base64Decode(itm.Password),
                                tel = MyEncryption.base64Decode(itm.tel),
                                Mobile = MyEncryption.base64Decode(itm.Mobile),
                                Email = MyEncryption.base64Decode(itm.Email),
                                UserName2 = itm.UserName2,
                                UserOP = itm.UserOP,
                                UserDate = itm.UserDate,
                                ChangePass = itm.ChangePass,
                                Branchs = itm.Branchs,
                                BranRoll = itm.BranRoll,
                                MainBran = itm.MainBran,
                                Photo = itm.Photo,
                                EmailPassword = MyEncryption.base64Decode(itm.EmailPassword),
                                Active = itm.Active,
                                Sign = itm.Sign,
                                Account1 = itm.Account1,
                                Account2 = itm.Account2,
                                Account3 = itm.Account3,
                                Account4 = itm.Account4,
                                Account5 = itm.Account5,
                                Account6 = itm.Account6                                
                            }).ToList();
                }
            }
            catch (Exception) { return null; }
        }



        public TblUsers Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.UsersFind(MyEncryption.base64Encode(this.UserName));
                    return (from itm in result
                            select new TblUsers
                            {
                                UserName = MyEncryption.base64Decode(itm.UserName),
                                FName = MyEncryption.base64Decode(itm.FName),
                                Password = MyEncryption.base64Decode(itm.Password),
                                tel = MyEncryption.base64Decode(itm.tel),
                                Mobile = MyEncryption.base64Decode(itm.Mobile),
                                Email = MyEncryption.base64Decode(itm.Email),
                                UserName2 = itm.UserName2,
                                UserOP = itm.UserOP,
                                UserDate = itm.UserDate,
                                ChangePass = itm.ChangePass,
                                Branchs = itm.Branchs,
                                BranRoll = itm.BranRoll,
                                MainBran = itm.MainBran,
                                Photo = itm.Photo,
                                EmailPassword = MyEncryption.base64Decode(itm.EmailPassword),
                                Active = itm.Active,
                                Sign = itm.Sign,
                                Account1 = itm.Account1,
                                Account2 = itm.Account2,
                                Account3 = itm.Account3,
                                Account4 = itm.Account4,
                                Account5 = itm.Account5,
                                Account6 = itm.Account6                                
                            }).FirstOrDefault();
                }
            }
            catch (Exception) { return null; }
        }
    }

    [Serializable]
    public class Prev
    {
        public short Interface { get; set; }
        public string KeyName { get; set; }
        public System.Nullable<short> FCode { get; set; }
        public System.Nullable<short> FCode2 { get; set; }
        public string Name { get; set; }


        public bool Update(string ConnectionStr)
        {
            try
            {

                return true;
            }
            catch { return false; }
        }

        public List<Prev> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext context = new DataERPDataContext(ConnectionStr))
                {
                    var result = context.PrevGetAll(this.Interface);
                    return (from itm in result
                            select new Prev
                            {
                                FCode = itm.FCode,
                                FCode2 = itm.FCode2,
                                KeyName = itm.KeyName,
                                Name = itm.Name,
                                Interface = itm.Interface
                            }).ToList();
                }
            }
            catch (Exception) { return null; }
        }

    }

    [Serializable]
    public class Transactions
    {
        public string TranDate { get; set; }
        public string TranTime { get; set; }
        public string UserName { get; set; }
        public string FormName { get; set; }
        public string FormAction { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string IP { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string lat2
        {
            get
            {
                return string.IsNullOrEmpty(this.lat) ? "" : @"<i class='fa fa-map-marker fa-2x'></i>";
            }
        }

        public Transactions()
        {
            this.TranDate = "";
            this.TranTime = "";
            this.UserName = "";
            this.FormName = "";
            this.FormAction = "";
            this.Description = "";
            this.Reason = "";
            this.IP = "";
            this.lat = "";
            this.lng = "";
        }

        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext context = new DataERP2DataContext(ConnectionStr))
                {
                    context.TransactionsInsert(this.TranDate, this.TranTime, this.UserName,this.FormName,this.FormAction, this.Description , this.Reason , this.IP,this.lat,this.lng);
                    return true;
                }
            }
            catch { return false; }
        }

        public List<Transactions> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext context = new DataERP2DataContext(ConnectionStr))
                {
                    var result = context.TransactionsGetAll(this.TranDate, this.UserName, this.FormName, this.FormAction);
                    return (from itm in result
                            orderby DateTime.Parse(itm.TranDate) descending
                            select new Transactions
                            {
                                TranDate = itm.TranDate,
                                TranTime = itm.TranTime,
                                UserName = itm.UserName,
                                Description = itm.Description,
                                FormAction = itm.FormAction,
                                FormName = itm.FormName,
                                Reason = itm.Reason,
                                IP = itm.IP,
                                lat = itm.lat,
                                lng = itm.lng
                            }).ToList();
                }
            }
            catch { return null; }
        }

        public List<Transactions> GetFormAction(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext context = new DataERP2DataContext(ConnectionStr))
                {
                    var result = context.TransactionsSelectFormAction();
                    return (from itm in result
                            select new Transactions
                            {
                                FormAction = itm.FormAction
                            }).ToList();
                }
            }
            catch { return null; }
        }

        public List<Transactions> GetUserName(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext context = new DataERP2DataContext(ConnectionStr))
                {
                    var result = context.TransactionsSelectUserName();
                    return (from itm in result
                            select new Transactions
                            {
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch { return null; }
        }

        public List<Transactions> GetFormName(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext context = new DataERP2DataContext(ConnectionStr))
                {
                    var result = context.TransactionsSelectFormName();
                    return (from itm in result
                            select new Transactions
                            {
                                FormName = itm.FormName
                            }).ToList();
                }
            }
            catch { return null; }
        }

    }


}