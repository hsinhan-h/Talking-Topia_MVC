
const { createApp, ref } = Vue;

const watch = createApp({
    data() {
        return {
            activeTab: 'language'  // 預設顯示語言學習
        };
    },
    methods: {
        switchTab(tab) {
            this.activeTab = tab;
        }
    }
});

watch.mount('#app');

