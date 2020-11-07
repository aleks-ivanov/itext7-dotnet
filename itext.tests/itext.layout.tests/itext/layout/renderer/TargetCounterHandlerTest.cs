using System;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Test;

namespace iText.Layout.Renderer {
    public class TargetCounterHandlerTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void BlockRendererAddByIDTest() {
            DivRenderer divRenderer = new DivRenderer(new Div());
            divRenderer.SetParent(new DocumentRenderer(null));
            String id = "id5";
            divRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            divRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(divRenderer, id));
        }

        [NUnit.Framework.Test]
        public virtual void TextRendererAddByIDTest() {
            TextRenderer textRenderer = new TextRenderer(new Text("a"));
            textRenderer.SetProperty(Property.TEXT_RISE, 20F);
            textRenderer.SetProperty(Property.CHARACTER_SPACING, 20F);
            textRenderer.SetProperty(Property.WORD_SPACING, 20F);
            textRenderer.SetProperty(Property.FONT, PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
            textRenderer.SetProperty(Property.FONT_SIZE, new UnitValue(UnitValue.POINT, 20));
            textRenderer.SetParent(new DocumentRenderer(null));
            String id = "id7";
            textRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            textRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(textRenderer, id));
        }

        [NUnit.Framework.Test]
        public virtual void TableRendererAddByIDTest() {
            TableRenderer tableRenderer = new TableRenderer(new Table(5));
            tableRenderer.SetParent(new DocumentRenderer(null));
            String id = "id5";
            tableRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            tableRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(tableRenderer, id));
        }

        [NUnit.Framework.Test]
        public virtual void ParagraphRendererAddByIDTest() {
            ParagraphRenderer paragraphRenderer = new ParagraphRenderer(new Paragraph());
            paragraphRenderer.SetParent(new DocumentRenderer(null));
            String id = "id5";
            paragraphRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            paragraphRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(paragraphRenderer, id));
        }

        [NUnit.Framework.Test]
        public virtual void ImageRendererAddByIDTest() {
            ImageRenderer imageRenderer = new ImageRenderer(new Image(ImageDataFactory.CreateRawImage(new byte[] { 50, 
                21 })));
            imageRenderer.SetParent(new DocumentRenderer(null));
            String id = "id6";
            imageRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            imageRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(imageRenderer, id));
        }

        [NUnit.Framework.Test]
        public virtual void LineRendererAddByIDTest() {
            LineRenderer lineRenderer = new LineRenderer();
            lineRenderer.SetParent(new DocumentRenderer(null));
            String id = "id6";
            lineRenderer.SetProperty(Property.ID, id);
            LayoutContext layoutContext = new LayoutContext(new LayoutArea(4, new Rectangle(50, 50)));
            lineRenderer.Layout(layoutContext);
            NUnit.Framework.Assert.AreEqual((int?)4, TargetCounterHandler.GetPageByID(lineRenderer, id));
        }
    }
}