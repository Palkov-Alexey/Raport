using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace SecondRaportCr
{
    public class SecondRaportCreate
    {
        public static void Create(string Whom, string LRaport, string[] TextRaport, string Date, string Position, string Rank, string Name1,
            string Whom2, string[] TextRaport2, string Position2, string Rank2, string Name2)
        {
            Word.Application application = new Word.Application(); //Создаём объект приложения ворд
            Word.Document doc = new Word.Document(); //Создаём объект документа
            try //Обработчик ошибок
            {
                doc = application.Documents.Add(); //Создаём текстовый документ
            }
            catch (Exception Error)
            {
                doc.Close();
                application.Quit();
                doc = null;
                application = null;
                throw Error;
            }
            doc.Content.Font.Name = "Times New Roman"; //Шрифт для всего документа
            doc.Content.Font.Size = 14; //размер шрифта для документа
            Word.Paragraphs docParagraphs;
            Word.Paragraph docParagraph;
            docParagraphs = doc.Paragraphs;
            docParagraphs.Add(); //создание нового абзаца
            docParagraph = docParagraphs[1];
            docParagraph.Range.Text = Whom; //Первый абзац документа
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;  //Выравнивание первого абзаца по правой стороне
            docParagraphs.Add();
            docParagraphs.Add();
            docParagraphs.Add();
            docParagraphs.Add();
            docParagraphs.Add();
            docParagraph = docParagraphs[5];
            int paragraph = 5;
            string t = LRaport; //Присваивание значения переменной
            docParagraph.Range.Text = t; //присваивание значения абзацу №5
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //выравнивание абзаца №5 по центру
            foreach (string text in TextRaport)
            {
                paragraph++;
                docParagraphs.Add();
                docParagraph = docParagraphs[paragraph];
                docParagraph.Range.ParagraphFormat.FirstLineIndent = application.CentimetersToPoints((float)1.25);
                string stTxt = text;
                docParagraph.Range.Text = stTxt;
                docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify; // выравнивание абзаца по ширине
            }
            docParagraphs.Add();
            paragraph++;
            object units = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend);
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.ParagraphFormat.FirstLineIndent = 0;
            object oType = Word.WdBreakType.wdSectionBreakContinuous;
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(2);
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Date + " г.";
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph++;
            docParagraphs.Add();
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Position;
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Rank + "\t\t\t" + Name1;
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            units = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend);
            oType = Word.WdBreakType.wdSectionBreakContinuous;
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(1);
            //Вторая ступень
            docParagraphs.Add();
            paragraph++;
            docParagraphs.Add();
            paragraph++;
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Whom2; //абзац документа
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;  //Выравнивание абзаца по правой стороне
            docParagraphs.Add();
            paragraph++;
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = t;
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            foreach (string text in TextRaport2)
            {
                paragraph++;
                docParagraphs.Add();
                docParagraph = docParagraphs[paragraph];
                docParagraph.Range.ParagraphFormat.FirstLineIndent = application.CentimetersToPoints((float)1.25);
                string stTxt = text;
                docParagraph.Range.Text = stTxt;
                docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify; // выравнивание абзаца по ширине
            }
            docParagraphs.Add();
            paragraph++;
            units = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend);
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.ParagraphFormat.FirstLineIndent = 0;
            oType = Word.WdBreakType.wdSectionBreakContinuous;
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(2);
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Date + " г.";
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph++;
            docParagraphs.Add();
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Position2;
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph++;
            docParagraphs.Add();
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.Text = Rank2 + "\t\t\t" + Name2;
            docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            units = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend);
            oType = Word.WdBreakType.wdSectionBreakContinuous;
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(1);
            application.Visible = true; //Ворд видим
        }
        ~SecondRaportCreate() { }
    }
}