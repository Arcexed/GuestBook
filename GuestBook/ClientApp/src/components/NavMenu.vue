<template>
    <header>
        <nav class="nav">
            <div class="container">
                <div class="nav__inner">
                  <router-link class="navbar-brand" to="/">GuestBook</router-link>
                  <router-link class="navbar-brand" to="/notes">Notes</router-link>
                    
                </div>
            </div>
        </nav>
    </header>
</template>


<style scoped>
.nav{
  margin-top: 15px;
}
.nav__inner{
  display: flex;
  justify-content: space-between;
}
</style>
<script>
    export default {
        name: "NavMenu",
    }
</script>