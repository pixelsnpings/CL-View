/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        PDFManager.cs
 * Date:        05-04-2016
 * Author:      Daniel Dorpinghaus
 * Description: This class implements the logic needed to output a pdf document.
 * 
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PDF_OutputTest
{
    class PDFManager
    {
        /**************************************************************************
         * WORK FIELDS 
         **************************************************************************/



        /**************************************************************************
         * PROPERTIES
         **************************************************************************/



        /**************************************************************************
         * SUBROUTINES
         **************************************************************************/
        /// <summary>
        /// This routine outputs a header on the page with some pertinant
        /// information.
        /// </summary>
        /// <param name="ladidah"></param>
        /// <param name="p_IntPageNumber">Page number is printed on the current page.</param>
        private void OutputHeader(XGraphics l_ObjCanvas, String ladidah, int p_IntPageNumber)
        {

            //Reference the font we'll use to render the text.
            XFont l_ObjFont = new XFont("Verdana", 20, XFontStyle.Bold);

            //Draw your text to the pdf.
            l_ObjCanvas.DrawString(String.Format("{0} {1:000}", ladidah, p_IntPageNumber), l_ObjFont, XBrushes.Black, 50, 50);

            //Draw the seporator line.
            l_ObjCanvas.DrawLine(new XPen(XColors.Black, 1), 25, 100, 587, 100);
        }


        /// <summary>
        /// This routine outputs a header on the page with some pertinant
        /// information.
        /// </summary>
        /// <param name="ladidah"></param>
        /// <param name="l_IntPageElementNumber">A page can display six result elements at a time. This 
        /// field indicates which element we're printing so that we can compute its location on the page
        /// for rendering.</param>
        private void OutputElement(XGraphics l_ObjCanvas, Object p_ObjResultItem, int p_IntElementIndex)
        {
            //Compute the locations we'll be needing.
            int l_IntX = 50;
            int l_IntY = 125 + (90 * p_IntElementIndex);

            //Reference the font we'll use to render the text.
            XFont l_ObjFontBold = new XFont("Verdana", 10, XFontStyle.Bold);
            XFont l_ObjFont = new XFont("Verdana", 10, XFontStyle.Regular);

            //Draw your text to the pdf.
            l_ObjCanvas.DrawString("Title", l_ObjFontBold, XBrushes.Black, l_IntX, l_IntY);
            l_ObjCanvas.DrawString("Name", l_ObjFont, XBrushes.Black, l_IntX, l_IntY + 15);
            l_ObjCanvas.DrawString("Info 1", l_ObjFont, XBrushes.Black, l_IntX, l_IntY + 30);
            l_ObjCanvas.DrawString("Info 2", l_ObjFont, XBrushes.Black, l_IntX, l_IntY + 45);

        }


        /// <summary>
        /// This routine assembles the complete document as outputs it to disk.
        /// </summary>
        /// <param name="p_StrFilename"></param>
        /// <returns></returns>
        public bool OutputPDF(String p_StrFilename)
        {
            bool l_BlnResult = false; //Default result is output failed.

            //Create a file stream.
            System.IO.FileStream l_ObjStream = new FileStream(p_StrFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //Build a reference t a new pdf file.
            PdfDocument l_ObjPDFDocument = new PdfDocument(l_ObjStream);

            //Add a new page to the pdf.
            PdfPage l_ObjPDFPage = l_ObjPDFDocument.AddPage();

            //Create a graphics context based on the pdf document so we can render the pdf.
            XGraphics l_ObjCanvas = XGraphics.FromPdfPage(l_ObjPDFPage);

            //Output the page header.
            OutputHeader(l_ObjCanvas, "HEADER DATA", 1);

            OutputElement(l_ObjCanvas, null, 0);
            OutputElement(l_ObjCanvas, null, 1);
            OutputElement(l_ObjCanvas, null, 2);
            OutputElement(l_ObjCanvas, null, 3);
            OutputElement(l_ObjCanvas, null, 4);
            OutputElement(l_ObjCanvas, null, 5);
            OutputElement(l_ObjCanvas, null, 6);

            //Save the document to disk as a pdf.
            l_ObjPDFDocument.Save(l_ObjStream, true);

            //Set the result.
            l_BlnResult = true;

            //Return the result.
            return l_BlnResult;
        }







    }
}
