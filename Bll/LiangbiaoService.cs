using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using Dto;
using Mapping;
using System.Web;
using System.Web.Mvc;


namespace Bll
{
    public class LiangbiaoService
    {

        public static List<String> GetTizhiQuestionList()
        {

            List<String> items = new List<String>();
            items.Add("您手脚发凉吗？");
            items.Add("您胃脘部、背部或腰膝部怕冷吗？");
            items.Add("您感到怕冷、衣服比别人穿得多吗？");
            items.Add("您比一般人耐受不了寒冷（冬天的寒冷，夏天的冷空调、电扇等）吗？");
            items.Add("您比别人容易患感冒吗？");
            items.Add("您吃(喝)凉的东西会感到不舒服或者怕吃(喝)凉东西吗？");
            items.Add("您受凉或吃(喝)凉的东西后，容易腹泻(拉肚子)吗？");
            items.Add("您感到手脚心发热吗？");
            items.Add("您感觉身体、脸上发热吗？");
            items.Add("您皮肢或口唇干吗？");
            items.Add("您口唇的颜色比一般人红吗？");
            items.Add("您容易便秘或大便干燥吗？");
            items.Add("您面部两颧潮红或偏红吗？");
            items.Add("您感到眼睛干涩吗？");
            items.Add("您感到口干咽燥、总想喝水吗？");
            items.Add("您容易疲乏吗？");
            items.Add("您容易气短（呼吸短促，接不上气）吗？");
            items.Add("您容易心慌吗？");
            items.Add("您容易头晕或站起时晕眩吗？");
            items.Add("您比别人容易患感冒吗？");
            items.Add("您喜欢安静、懒得说话吗？");
            items.Add("您说话声音低弱无力吗？");
            items.Add("您活动量稍在太容易出虚汗吗？");
            items.Add("您感到胸闷或腹部胀满吗？");
            items.Add("您感到身体沉重不轻松或不爽快吗？");
            items.Add("您腹部肥满松软吗？");
            items.Add("您有额部油脂分泌多的现象吗？");
            items.Add("您上眼睑比别人肿(上眼睑有轻微隆起现象)吗？");
            items.Add("您嘴里有黏黏的感觉吗？");
            items.Add("您平时痰多，特别咽喉部总感到有痰堵着吗？");
            items.Add("您活动量稍在太容易出虚汗吗？");
            items.Add("您面部或鼻部有油腻感或者油亮发光吗？");
            items.Add("您容易生痤疮或疮疖吗？");
            items.Add("您感到口苦或嘴里有异味吗？");
            items.Add("您大便黏滞不爽、有解不尽的感觉吗？");
            items.Add("您小便明尿道有发热感、尿色浓(深)吗？");
            items.Add("您带下色黄(白带颜色发黄)吗(限女性回答)？");
            items.Add("您的阴囊部位潮湿吗(阴男性回答)？");
            items.Add("您的皮肤在不知不觉中会出现青紫瘀斑(皮下出血)吗？");
            items.Add("您两颧部有细微红丝吗？");
            items.Add("您身体上哪里疼痛吗？");
            items.Add("您面色晦黯或容易出现褐斑吗？");
            items.Add("您容易有黑眼圈吗？");
            items.Add("您容易忘事(健忘)吗？");
            items.Add("您口唇颜色偏黯吗？");
            items.Add("您感到闷闷不乐、情结低沉吗？");
            items.Add("您容易精神紧张、焦虑不安吗？");
            items.Add("您多愁善感、感情脆弱吗？");
            items.Add("您容易感到害怕或受到惊吓吗？");
            items.Add("您胁肋部或乳房胀痛吗？");
            items.Add("您无缘无故叹气吗？");
            items.Add("您咽喉部有异物感,且吐之不出、咽之不下吗？");
            items.Add("您没有感冒时也会打喷嚏吗？");
            items.Add("您没有感冒时也会鼻塞、流鼻涕吗？");
            items.Add("您有因季节变化、温度变化或异味等原因而咳喘的现象吗？");
            items.Add("您容易过敏(对药物、食物、气味、花粉或在季节交替、气候变化时)吗？");
            items.Add("您的皮肤容易起荨麻疹(风团、风疹块、风疙瘩)吗？");
            items.Add("您的皮肤因过敏出现过紫癜(紫红色瘀点、瘀斑)吗？");
            items.Add("您的皮肤一抓就红，并出现抓痕吗？");
            items.Add("您精力充沛吗？");
            items.Add("您容易疲乏吗＊？");
            items.Add("您说话声音低弱无力吗＊？");
            items.Add("您感到闷闷不乐、情绪低沉吗＊？");
            items.Add("您比一般人耐受不了寒冷(冬天的寒冷，夏天的冷空调、电扇等)吗＊？");
            items.Add("您能适应外界自然和社会环境的变化吗？");
            items.Add("您容易失眠吗＊？");
            items.Add("您容易忘事(健忘)吗;＊？");

            return items;

        }
       
    }
}
