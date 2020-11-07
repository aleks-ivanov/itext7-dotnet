using System;
using System.Collections.Generic;
using iText.Layout.Properties;

namespace iText.Layout.Renderer {
    /// <summary>Handler to handle target-counter logic.</summary>
    public class TargetCounterHandler {
        /// <summary>Pages for all renderers with id.</summary>
        private IDictionary<String, int?> renderersPages = new Dictionary<String, int?>();

        /// <summary>Indicates if relayout is required.</summary>
        private bool isRelayoutRequired = false;

        /// <summary>
        /// Creates a copy of the given
        /// <see cref="TargetCounterHandler"/>
        /// instance.
        /// </summary>
        /// <param name="targetCounterHandler">
        /// 
        /// <see cref="TargetCounterHandler"/>
        /// instance to be copied
        /// </param>
        public TargetCounterHandler(iText.Layout.Renderer.TargetCounterHandler targetCounterHandler) {
            this.renderersPages = targetCounterHandler.renderersPages;
        }

        /// <summary>
        /// Creates a new
        /// <see cref="TargetCounterHandler"/>
        /// instance.
        /// </summary>
        public TargetCounterHandler() {
        }

        /// <summary>Adds renderer's page to the root renderer map.</summary>
        /// <param name="renderer">renderer from which page and root renderer will be taken.</param>
        public static void AddPageByID(IRenderer renderer) {
            String id = renderer.GetProperty<String>(Property.ID);
            if (id != null) {
                iText.Layout.Renderer.TargetCounterHandler targetCounterHandler = GetTargetCounterHandler(renderer);
                if (targetCounterHandler != null && renderer.GetOccupiedArea() != null) {
                    int? prevPageNumber = targetCounterHandler.renderersPages.Get(id);
                    int currentPageNumber = renderer.GetOccupiedArea().GetPageNumber();
                    if (prevPageNumber == null || currentPageNumber > prevPageNumber) {
                        targetCounterHandler.renderersPages.Put(id, currentPageNumber);
                        targetCounterHandler.isRelayoutRequired = true;
                    }
                }
            }
        }

        /// <summary>Gets page from renderer using given id.</summary>
        /// <param name="renderer">renderer from which root renderer will be taken</param>
        /// <param name="id">key to the renderersPages Map</param>
        /// <returns>page on which renderer was layouted</returns>
        public static int? GetPageByID(IRenderer renderer, String id) {
            iText.Layout.Renderer.TargetCounterHandler targetCounterHandler = GetTargetCounterHandler(renderer);
            return targetCounterHandler == null ? null : targetCounterHandler.renderersPages.Get(id);
        }

        /// <summary>Indicates if page value was defined for this id.</summary>
        /// <param name="renderer">renderer from which root renderer will be taken</param>
        /// <param name="id">target id</param>
        /// <returns>true if value is defined for this id, false otherwise</returns>
        public static bool IsValueDefinedForThisID(IRenderer renderer, String id) {
            iText.Layout.Renderer.TargetCounterHandler targetCounterHandler = GetTargetCounterHandler(renderer);
            return targetCounterHandler != null && targetCounterHandler.renderersPages.ContainsKey(id);
        }

        /// <summary>Indicates if relayout is required.</summary>
        /// <returns>true if relayout is required, false otherwise</returns>
        public virtual bool IsRelayoutRequired() {
            return isRelayoutRequired;
        }

        private static iText.Layout.Renderer.TargetCounterHandler GetTargetCounterHandler(IRenderer renderer) {
            IRenderer rootRenderer = renderer;
            while (rootRenderer.GetParent() != null) {
                rootRenderer = rootRenderer.GetParent();
            }
            if (rootRenderer is DocumentRenderer) {
                return ((DocumentRenderer)rootRenderer).GetTargetCounterHandler();
            }
            return null;
        }
    }
}