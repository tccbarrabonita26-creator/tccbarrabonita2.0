// ============================================
// MÓDULO PRINCIPAL - Barra Bonita Turismo
// ============================================

const BarraBonitaTurismo = (function() {
    'use strict';
    
    // Elementos DOM
    let modal, modalImage, modalTitle, modalDesc, menuToggle, navLinks;
    
    // ============================================
    // FILTROS - VERSÃO SIMPLES E ESTÁVEL
    // ============================================
    
    const initFilters = () => {
        const filterBtns = document.querySelectorAll('.filter-btn');
        const attractionCards = document.querySelectorAll('.attraction-card');
        
        if (!filterBtns.length || !attractionCards.length) return;
        
        const filterAttractions = (filter) => {
            attractionCards.forEach(card => {
                const category = card.getAttribute('data-category');
                
                if (filter === 'all' || category === filter) {
                    // Mostrar card com animação suave
                    card.style.display = 'flex';
                    setTimeout(() => {
                        card.style.opacity = '1';
                        card.style.transform = 'scale(1)';
                    }, 10);
                } else {
                    // Esconder card com animação
                    card.style.opacity = '0';
                    card.style.transform = 'scale(0.8)';
                    setTimeout(() => {
                        card.style.display = 'none';
                    }, 200);
                }
            });
        };
        
        // Adicionar evento aos botões de filtro
        filterBtns.forEach(btn => {
            btn.addEventListener('click', function() {
                const filter = this.getAttribute('data-filter');
                
                // Atualizar estado visual dos botões
                filterBtns.forEach(b => {
                    b.classList.remove('filter-btn-active');
                    b.classList.add('filter-btn-inactive');
                });
                this.classList.add('filter-btn-active');
                this.classList.remove('filter-btn-inactive');
                
                // Aplicar filtro
                filterAttractions(filter);
            });
        });
        
        // Resetar estilos iniciais
        attractionCards.forEach(card => {
            card.style.display = 'flex';
            card.style.opacity = '1';
            card.style.transform = 'scale(1)';
            card.style.transition = 'opacity 0.2s ease, transform 0.2s ease';
        });
    };
    
    // ============================================
    // FAQ ACCORDION
    // ============================================
    
    const initFaq = () => {
        const faqItems = document.querySelectorAll('.faq-item');
        
        faqItems.forEach(item => {
            const question = item.querySelector('.faq-question');
            if (question) {
                question.addEventListener('click', () => {
                    // Fechar outros itens (opcional)
                    faqItems.forEach(other => {
                        if (other !== item && other.classList.contains('active')) {
                            other.classList.remove('active');
                        }
                    });
                    item.classList.toggle('active');
                });
            }
        });
    };
    
    // ============================================
    // MODAL
    // ============================================
    
    const initModal = () => {
        modal = document.getElementById('modal');
        const closeBtn = document.querySelector('.modal-close');
        
        if (closeBtn) {
            closeBtn.onclick = closeModal;
        }
        
        if (modal) {
            modal.addEventListener('click', (e) => {
                if (e.target === modal) {
                    closeModal();
                }
            });
        }
    };
    
    const openModal = (title, description, imageUrl) => {
        if (!modal) return;
        
        modalTitle = document.getElementById('modalTitle');
        modalDesc = document.getElementById('modalDesc');
        modalImage = document.getElementById('modalImage');
        
        if (modalTitle) modalTitle.innerText = title;
        if (modalDesc) modalDesc.innerText = description;
        if (modalImage) modalImage.src = imageUrl;
        
        modal.style.display = 'flex';
        document.body.style.overflow = 'hidden';
    };
    
    const closeModal = () => {
        if (!modal) return;
        modal.style.display = 'none';
        document.body.style.overflow = 'auto';
    };
    
    // ============================================
    // MENU MOBILE
    // ============================================
    
    const initMobileMenu = () => {
        menuToggle = document.getElementById('menuToggle');
        navLinks = document.getElementById('navLinks');
        
        if (menuToggle && navLinks) {
            menuToggle.addEventListener('click', () => {
                navLinks.classList.toggle('active');
            });
        }
    };
    
    // ============================================
    // SMOOTH SCROLL
    // ============================================
    
    const initSmoothScroll = () => {
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function(e) {
                const href = this.getAttribute('href');
                if (href === '#' || href === '') return;
                
                e.preventDefault();
                const target = document.querySelector(href);
                if (target) {
                    target.scrollIntoView({ behavior: 'smooth' });
                    
                    // Fechar menu mobile se aberto
                    if (navLinks && navLinks.classList.contains('active')) {
                        navLinks.classList.remove('active');
                    }
                }
            });
        });
    };
    
    // ============================================
    // NAVBAR SCROLL EFFECT
    // ============================================
    
    const initNavbarScroll = () => {
        const navbar = document.querySelector('.navbar-custom');
        if (!navbar) return;
        
        window.addEventListener('scroll', () => {
            if (window.scrollY > 50) {
                navbar.style.backgroundColor = 'rgba(255, 255, 255, 0.98)';
                navbar.style.boxShadow = '0 2px 10px rgba(0, 0, 0, 0.05)';
            } else {
                navbar.style.backgroundColor = 'rgba(255, 255, 255, 0.95)';
                navbar.style.boxShadow = 'none';
            }
        });
    };
    
    // ============================================
    // INICIALIZAÇÃO
    // ============================================
    
    const init = () => {
        initFilters();
        initFaq();
        initModal();
        initMobileMenu();
        initSmoothScroll();
        initNavbarScroll();
    };
    
    // Retornar API pública
    return {
        init: init,
        openModal: openModal,
        closeModal: closeModal
    };
})();

// Inicializar quando o DOM estiver pronto
document.addEventListener('DOMContentLoaded', () => {
    BarraBonitaTurismo.init();
});