package com.lg;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        System.out.println("JPA Project");
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager entityManager = factory.createEntityManager();
        entityManager.getTransaction().begin();
        //ROLE
        Role role1 = new Role(null, "admin");
        entityManager.persist(role1);
        Role role2 = new Role(null, "user");
        entityManager.persist(role2);
        Role role3 = new Role(null, "moderator");
        entityManager.persist(role3);
        Role role4 = new Role(null, "guest");
        entityManager.persist(role4);
        Role role5 = new Role(null, "banned");
        entityManager.persist(role5);
        //UZYTKOWNICY
        User user1 = new User(null, "test1", "test1", "Jan" , "Brzechwa", Sex.sex.MALE);
        entityManager.persist(user1);
        User user2 = new User(null, "test2", "test2", "Adam", "Kowalski", Sex.sex.MALE );
        entityManager.persist(user2);
        User user3 = new User(null, "test3", "test3", "Katarzyna", "Kowalska", Sex.sex.FEMALE);
        entityManager.persist(user3);
        User user4 = new User(null, "test4", "test4", "Adam", "Szulc", Sex.sex.MALE);
        entityManager.persist(user4);
        User user5 = new User(null,"test5","test5","Zosia","Bednarczyk", Sex.sex.FEMALE);
        entityManager.persist(user5);
        //aktualizacja hasła z merge
        User user = entityManager.find(User.class, 1L);
        user.setPassword("test1_updated");
        entityManager.merge(user);

        //Kowalscy
        System.out.println("Kowalscy");
        List<User> kowalscy = entityManager.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'", User.class).getResultList();
        for (User kowalski : kowalscy){
            System.out.println(kowalski.getFirstName()+" "+kowalski.getLastName());
        }
        //usuniecie roli o id 5
        Role role = entityManager.find(Role.class, 5L);
        entityManager.remove(role);

        //wszystkie kobiety
        System.out.println("Kobiety");
        List<User> females = entityManager.createQuery("SELECT u FROM User u WHERE u.gender = 'FEMALE'",User.class).getResultList();
        for (User female : females){
            System.out.println(female.getFirstName()+" "+female.getLastName());
        }

        User user6 = new User(null, "test6","test6","Barnaba","Nikowiecki", Sex.sex.MALE);
        user6.addRole(role1);
        user6.addRole(role2);

        UsersGroup usersGroup1 = new UsersGroup(null);
        user6.addGroup(usersGroup1);
        entityManager.persist(usersGroup1);
        usersGroup1.addUser(user6);
        entityManager.persist(user6);


        //dodatkowe
        File image = new File("thorin.png");
        byte[] imageBytes = new byte[(int) image.length()];
        FileInputStream fis = new FileInputStream(image);
        fis.read(imageBytes);
        fis.close();
        user6.setImage(imageBytes);

        entityManager.getTransaction().commit();
        entityManager.close();
        factory.close();
    }
}
