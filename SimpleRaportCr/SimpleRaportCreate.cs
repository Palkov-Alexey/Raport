using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace SimpleRaportCr
{
    public class SimpleRaportCreate
    {
        public static void Create(string Whom, string LRaport, string[] TextRaport, string Date, string Position, string Rank, string Name1)
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
                docParagraph.Range.ParagraphFormat.FirstLineIndent = application.CentimetersToPoints((float)1.25); //отступ 1.25
                string stTxt = text;
                docParagraph.Range.Text = stTxt;
                docParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify; // выравнивание абзаца по ширине
            }
            docParagraphs.Add();
            paragraph++;
            //Разрыв раздела и добавление колонок
            object units = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend); //перевод курсора в конец документа
            docParagraph = docParagraphs[paragraph];
            docParagraph.Range.ParagraphFormat.FirstLineIndent = 0;
            object oType = Word.WdBreakType.wdSectionBreakContinuous; //разрыв раздела на текущей странице
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(2); //создание 2 колонок в разделе
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
            //Новый разрыв раздела и замена 2 колонок на 1
            units = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            application.Selection.EndKey(ref units, ref extend);
            oType = Word.WdBreakType.wdSectionBreakContinuous;
            application.Selection.InsertBreak(oType);
            application.Selection.PageSetup.TextColumns.SetCount(1);
            application.Visible = true; //Ворд видим
        }
    }
}
